using Microsoft.EntityFrameworkCore;
using SistemaGestionEscolar.Models;

namespace SistemaGestionEscolar.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Maestro> Maestros { get; set; }

    }
}