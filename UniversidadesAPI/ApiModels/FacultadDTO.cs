using UniversidadesAPI.Models;

namespace UniversidadesAPI.ApiModels
{
    public class FacultadDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public bool Publica { get; set; }
        public string Direccion { get; set; }
        public string PaginaWeb { get; set; }
        public int? UniversidadId { get; set; }
        public string NombreUniversidad { get; set; }
        public EstadisticasDTO Estadisticas { get; set; }
    }
}
