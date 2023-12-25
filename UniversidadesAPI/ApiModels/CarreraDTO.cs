namespace UniversidadesAPI.ApiModels
{
    public class CarreraDTO
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
        public EstadisticasDTO Estadisticas { get; set; }
    }
}
