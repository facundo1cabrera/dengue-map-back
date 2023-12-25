using Microsoft.EntityFrameworkCore;
using UniversidadesAPI.Models;

namespace UniversidadesAPI
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Universidad> Universidades { get; set; }
        public DbSet<Facultad> Facultades { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<EstadisticaEntidad> EstadisticaEntidades { get; set; }
        public DbSet<Opinion> Opiniones { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
