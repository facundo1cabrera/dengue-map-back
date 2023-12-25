namespace UniversidadesAPI.Models
{
    public class Universidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Logo { get; set; }
        public string? Imagen { get; set; }
        public bool? EsPublica { get; set; }
        public string? Direccion { get; set; }
        public string? Provincia { get; set; }
        public string? PaginaWeb { get; set; }
        public bool? TieneCursoIngreso { get; set; }
        public List<Facultad>? Facultades { get; set; }
        public int? EstadisticaEntidadId { get; set; }
        public EstadisticaEntidad? EstadisticaEntidad { get; set; }
    }
}
