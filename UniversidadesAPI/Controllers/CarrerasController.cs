using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversidadesAPI.ApiModels;
using UniversidadesAPI.Models;
using UniversidadesAPI.Utils;

namespace UniversidadesAPI.Controllers
{
    [ApiController]
    [Route("api/v1/carreras")]
    public class CarrerasController: ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public CarrerasController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<GetCarrerasDTO>> GetCarreras()
        {
            var carrerasDB = await _dbContext.Carreras.Include(x => x.EstadisticaEntidad).ToListAsync();

            var carrera = new GetCarrerasDTO()
            {
                Carreras = carrerasDB.Select(x => x.MapToCarreraDTO()).ToList()
            };

            return Ok(carrera);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCarreras([FromBody] CreateCarreraDTO carreraDTO)
        {
            var carrera = carreraDTO.MapToCarrera();
            _dbContext.Add(carrera);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("opinion")]
        public async Task<ActionResult> CreateOpinion([FromBody] Opinion opinion)
        {
            _dbContext.Add(opinion);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
