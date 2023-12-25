namespace UniversidadesAPI.Models
{
    public class Opinion
    {
        public int Id { get; set; }
        public int? ExigenciaAcademica { get; set; }
        public int? RelacionCalidadPrecio { get; set; }
        public int? Politizacion { get; set; }
        public int? CalidadAdministrativa { get; set; }
        public int? DisponibilidadDeHorarios { get; set; }
        public int? CalidadDeProfesores { get; set; }
        public int? DificultadIngreso { get; set; }
        public int? BolsaDeTrabajo { get; set; }
        public int? SalidaLaboral { get; set; }
        public int? Infraestructura { get; set; }
        public int? SatisfaccionProfesion { get; set; }
        public int? CalidadUniversidad { get; set; }
        public bool VolveriasAEstudiarLoMismo { get; set; }

        // Navigational Properties
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? CarreraId { get; set; }
        public Carrera? Carrera { get; set; }
    }
}
