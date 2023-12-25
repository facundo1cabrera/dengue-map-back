namespace UniversidadesAPI.Models
{
    public class Carrera
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Publica { get; set; }
        public string? Direccion { get; set; }
        public string? PlanDeEstudiosUrl { get; set; }
        public int? PrecioCuota { get; set; }
        public int? CargaHorarioSemanal { get; set; }
        public int? TiempoPromedioFinalizacion { get; set; }
        public int? PorcentajeDesercion { get; set; }

        // Navigational properties
        public int? FacultadId { get; set; }
        public Facultad? Facultad { get; set; }
        public List<Opinion>? Opiniones { get; set; }
        public int? EstadisticaEntidadId { get; set; }
        public EstadisticaEntidad? EstadisticaEntidad { get; set; }
    }
}
