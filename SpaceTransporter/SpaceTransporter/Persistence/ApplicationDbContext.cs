using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SpaceTransporter.Models.Entities;

namespace SpaceTransporter.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Planet> Planets { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ship>()
                .HasOne<Planet>(p => p.Planet)
                .WithMany(x => x.Ships)
                .HasForeignKey(k => k.PlanetId)
                .IsRequired(false);
        }
    }
}