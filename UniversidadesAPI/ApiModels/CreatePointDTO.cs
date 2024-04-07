using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace DengueMap.ApiModels
{
    public class CreatePointDTO
    {
        [Range(-90, 90)]
        public double Latitud { get; set; }

        [Range(-180, 180)]
        public double Longitud { get; set; }
        public long CreatedAt { get; set; }
        public int IntensityLevel { get; set; }
    }
}