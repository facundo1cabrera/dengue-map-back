using System.Drawing;

namespace UniversidadesAPI.Models
{
    public class Facultad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Imagen { get; set; }
        public bool Publica { get; set; }
        public string? Direccion { get; set; }
        public string? PaginaWeb { get; set; }
        public int? UniversidadId { get; set; }
        public Universidad? Universidad { get; set; }
        public List<Carrera>? Carreras { get; set; }
        public int? EstadisticaEntidadId { get; set; }
        public EstadisticaEntidad? EstadisticaEntidad { get; set; }
        // public Point Ubicacion { get; set; }
    }
}
