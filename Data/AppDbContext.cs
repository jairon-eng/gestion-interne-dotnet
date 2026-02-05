using Microsoft.EntityFrameworkCore;
using GestionInterne.Models;

namespace GestionInterne.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Equipement> Equipements { get; set; } = null!;
    }
}
