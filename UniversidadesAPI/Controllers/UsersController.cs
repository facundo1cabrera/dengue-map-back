using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RestSharp;
using RestSharp.Authenticators;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DengueMap.ApiModels;
using DengueMap.Models;
using DengueMap.Utils;

namespace DengueMap.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UsersController: ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _config;

        public UsersController(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _config = configuration;
        }

        private async Task SendConfirmationEmail(string confirmationCode, string email)
        {

            var options = new RestClientOptions("https://api.mailgun.net/v3")
            {
                Authenticator = new HttpBasicAuthenticator("api", _config.GetValue<string>("EmailSenderKey"))
            };

            var backendUrl = _config.GetValue<string>("BackendUrl");

            RestClient client = new RestClient(options);
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "aulers.com", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Aulers <users@aulers.com>");
            request.AddParameter("to", email);
            request.AddParameter("subject", "Confirmá tu cuenta en Aulers");
            var html = $"<!DOCTYPE html><html lang=\"es\"><head><meta charset=\"UTF-8\"><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"><title>Confirmación de Cuenta - Aulers.com</title></head><body style=\"font-family: Arial, sans-serif; margin: 0; padding: 0; background-color: #f4f4f4;\"><table role=\"presentation\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" style=\"margin: auto; background-color: #ffffff;\"><tr><td style=\"padding: 20px;\"><h2 style=\"color: #333333;\">Confirmación de Cuenta</h2><p>Bienvenido/a a Aulers.com. Estamos emocionados de tenerte como parte de nuestra comunidad educativa. Para confirmar tu cuenta, haz clic en el siguiente enlace:</p><p><a href=\"{backendUrl}/api/v1/users/{confirmationCode}\" style=\"color: #007BFF; text-decoration: none;\">Confirmar Cuenta</a></p><p>Una vez confirmada tu cuenta, podrás acceder a toda la informacion acerca de instituciones educativas de argentina en aulers.com</p><p>Gracias por unirte a nosotros.</p><p>Atentamente,<br>El equipo de Aulers.com</p></td></tr><tr><td style=\"background-color: #007BFF; padding: 10px; text-align: center; color: #ffffff;\">© 2024 Aulers.com. Todos los derechos reservados.</td></tr></table></body></html>";
            request.AddParameter("html", html);

            await client.PostAsync(request);
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<AuthResponse>> CreateUser(RegisterDTO registerDTO)
        {
            var userDB = await _dbContext.Users.Where(x => x.Email == registerDTO.Email).FirstOrDefaultAsync();
            if (userDB != null)
            {
                return BadRequest("User already has an account");
            }

            var user = new User()
            {
                Email = registerDTO.Email,
                EmailConfirmed = false,
                Username = registerDTO.Email,
                ConfirmationCode = Guid.NewGuid().ToString(),
                Password = BCrypt.Net.BCrypt.HashPassword(registerDTO.Password)
            };

            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();

            await SendConfirmationEmail(user.ConfirmationCode, user.Email);

            return Ok();
        }

        [HttpGet("{confirmationCode}")]
        public async Task<RedirectResult> ConfirmEmail(string confirmationCode)
        {
            var frontendUrl = _config.GetValue<string>("FrontendUrl");
            var userDB = await _dbContext.Users.Where(x => x.ConfirmationCode ==  confirmationCode).FirstOrDefaultAsync();

            if (userDB == null)
            {
                return Redirect($"{frontendUrl}/login");
            }

            userDB.ConfirmationCode = null;
            userDB.EmailConfirmed = true;

            await _dbContext.SaveChangesAsync();

            return Redirect($"{frontendUrl}/login");
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginDTO loginDTO)
        {
            var userDB = await _dbContext.Users.Where(x => x.Email == loginDTO.Email).FirstOrDefaultAsync();

            if (userDB == null)
            {
                return NotFound();
            }

            var samePassword = BCrypt.Net.BCrypt.Verify(loginDTO.Password, userDB.Password) && userDB.EmailConfirmed;

            if (!samePassword)
            {
                return NotFound();
            }
            return Ok(CreateToken(loginDTO.Email));
        }

        private AuthResponse CreateToken(string email)
        {
            var jwt = _config.GetSection("Jwt").Get<Jwt>();

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("email", email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    jwt.Issuer,
                    jwt.Audience,
                    claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials
                );

            return new AuthResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = DateTime.Now.AddDays(1)
            };
        }
    }
}
