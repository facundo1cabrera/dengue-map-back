using NetTopologySuite.Geometries;

namespace DengueMap.Models
{
    public class MapPoint
    {
        public int Id { get; set; }
        public Point Position { get; set; }
        public long CreatedTime { get; set; }
        public int IntensityLevel { get; set; }
    }
}
