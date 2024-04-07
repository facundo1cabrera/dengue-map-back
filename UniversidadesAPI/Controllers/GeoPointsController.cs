using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DengueMap.ApiModels;
using DengueMap.Models;
using DengueMap.Utils;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace DengueMap.Controllers
{
    [ApiController]
    [Route("api/v1/points")]
    public class GeoPointsController: ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _config;

        public GeoPointsController(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _config = configuration;
        }

        [HttpGet]
        [Route("distance")]
        public async Task<ActionResult> GetPs([FromQuery] double long1, [FromQuery] double lat, [FromQuery] double distance, [FromQuery] long lastUpdate) {



            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var ubicacionUsuario = geometryFactory.CreatePoint(new Coordinate(long1, lat));

            var distanceCalculated = (double) 180;
            Console.WriteLine("-- --");
            Console.WriteLine(distanceCalculated);

            var points = await _dbContext.GeoPoints.Where(x => 
                    x.CreatedTime > lastUpdate &&
                    x.Position.IsWithinDistance(ubicacionUsuario, distanceCalculated)
                ).Select(x => new PointDTO() {
                    Latitud = x.Position.Y,
                    Longitud = x.Position.X,
                    Intensity = x.IntensityLevel
                }).ToListAsync();

            return Ok(points);
        }

        // [HttpGet]
        // [Route("test")]
        // public async Task<ActionResult> Test([FromQuery] long lastUpdate) {
        
        //     var points = await _dbContext.GeoPoints.Where(x => x.CreatedTime > lastUpdate)
        //         .Select(x => new PointDTO() {
        //             Latitud = x.Position.X,
        //             Longitud = x.Position.Y,
        //             Intensity = x.IntensityLevel
        //         }).ToListAsync();

        //     return Ok(points);
        // }

        [HttpPost]
        public async Task<ActionResult> CreatePoint([FromBody] CreatePointDTO createPointDTO) {

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var newPoint = new MapPoint() {
                CreatedTime = createPointDTO.CreatedAt,
                Position = geometryFactory.CreatePoint(new Coordinate(createPointDTO.Longitud, createPointDTO.Latitud)),
                IntensityLevel = createPointDTO.IntensityLevel
            };

            _dbContext.Add(newPoint);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
