using System.ComponentModel.DataAnnotations;
using UniversidadesAPI.Models;

namespace UniversidadesAPI.ApiModels
{
    public class CreateCarreraDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public bool Publica { get; set; }
        public string? Direccion { get; set; }
        public string? PlanDeEstudiosUrl { get; set; }
        public int? PrecioCuota { get; set; }
        public int? CargaHorarioSemanal { get; set; }
        public int? TiempoPromedioFinalizacion { get; set; }
        public int? PorcentajeDesercion { get; set; }
        public int? FacultadId { get; set; }
    }
}
