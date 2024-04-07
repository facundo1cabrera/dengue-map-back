using NetTopologySuite.Geometries;

namespace DengueMap.ApiModels
{
    public class GetPointsDto
    {
        public Point point1 { get; set; }
        public Point point2 { get; set; }
        public Point point3 { get; set; }
        public Point point4 { get; set; }
        public long CreatedAt { get; set; }
    }
}