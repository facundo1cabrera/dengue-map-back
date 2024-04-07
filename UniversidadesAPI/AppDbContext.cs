using Microsoft.EntityFrameworkCore;
using DengueMap.Models;
using Azure.Core.GeoJson;

namespace DengueMap
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("postgis");
        }

        public DbSet<MapPoint> GeoPoints { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
