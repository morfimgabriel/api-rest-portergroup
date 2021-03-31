using ApiRestPorter.Core.Entities;
using ApiRestPorter.Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace ApiRestPorter.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ResidentConfiguration());
            modelBuilder.ApplyConfiguration(new ApartmentConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Resident> Residents { get; set; }

        public DbSet<Apartment> Apartments { get; set; }
    }
}
