using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversidadesAPI.ApiModels;
using UniversidadesAPI.Models;
using UniversidadesAPI.Utils;

namespace UniversidadesAPI.Controllers
{
    [ApiController]
    [Route("api/v1/facultades")]
    public class FacultadesController: ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public FacultadesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<FacultadDTO>>> GetFacultades()
        {
            var facultades = await _dbContext.Facultades.Include(x => x.EstadisticaEntidad).Include(x => x.Universidad).ToListAsync();

            var facultadesDTO = facultades.Select(x => x.MapToFacultadDTO());

            return Ok(facultadesDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CreateFacultad(Facultad facultad)
        {
            _dbContext.Add(facultad);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }


    }
}
