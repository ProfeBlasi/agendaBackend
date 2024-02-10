using Domain.Entidades;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class Context(DbContextOptions<Context> options) : DbContext(options)
    {
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Holiday> Holiday { get; set; }
        public DbSet<AssistanceStatus> AssistanceStatus { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentTest> StudentTest { get; set; }
        public DbSet<StudentObservation> StudentObservation { get; set; }
        public DbSet<StudentPeriod> StudentPeriod { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<Observations> Observations { get; set; }
        public DbSet<Period> Period { get; set; }
        public DbSet<Reminder> Reminder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(e => e.Average)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<StudentTest>()
                .Property(e => e.Qualification)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<StudentPeriod>()
                .Property(e => e.Qualification)
                .HasColumnType("decimal(18, 2)");
        }
    }
}
