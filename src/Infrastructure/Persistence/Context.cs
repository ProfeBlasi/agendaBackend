using Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options){  }

        public DbSet<Asistencia> Asistencia { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<DiaNoLaborable> DiaNoLaborable { get; set; }
        public DbSet<EstadoAsistencia> EstadoAsistencia { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<EstudianteEvaluacion> EstudianteEvaluacion { get; set; }
        public DbSet<EstudianteObservaciones> EstudianteObservaciones { get; set; }
        public DbSet<EstudiantePeriodo> EstudiantePeriodo { get; set; }
        public DbSet<Evaluacion> Evaluacion { get; set; }
        public DbSet<Observaciones> Observaciones { get; set; }
        public DbSet<Periodo> Periodo { get; set; }
        public DbSet<Recordatorio> Recordatorio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>()
                .Property(e => e.Promedio)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EstudianteEvaluacion>()
                .Property(e => e.Calificacion)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<EstudiantePeriodo>()
                .Property(e => e.Calificacion)
                .HasColumnType("decimal(18, 2)");
        }
    }
}
