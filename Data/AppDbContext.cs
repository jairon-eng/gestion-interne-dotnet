using Microsoft.EntityFrameworkCore;
using GestionInterne.Models;

namespace GestionInterne.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Equipement> Equipements { get; set; } = null!;
        public DbSet<Affectation> Affectations => Set<Affectation>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Affectation>()
        .HasOne(a => a.Equipement)
        .WithMany(e => e.Affectations)
        .HasForeignKey(a => a.EquipementId)
        .OnDelete(DeleteBehavior.Cascade);
}


    }
}
