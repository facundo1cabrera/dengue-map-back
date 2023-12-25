using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversidadesAPI.Models;

namespace UniversidadesAPI.Controllers
{
    [ApiController]
    [Route("api/v1/universidades")]
    public class UniversidadesController: ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public UniversidadesController(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetUniversidades()
        {
            var universidades = await _dbContext.Universidades.ToListAsync();

            return Ok(universidades);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUniversidad([FromBody] Universidad universidad)
        {
            _dbContext.Add(universidad);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
