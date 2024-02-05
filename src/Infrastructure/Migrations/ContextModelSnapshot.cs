﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entidades.Asistencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EstadoAsistenciaId")
                        .HasColumnType("int");

                    b.Property<int>("EstudianteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstadoAsistenciaId");

                    b.HasIndex("EstudianteId");

                    b.ToTable("Asistencia");
                });

            modelBuilder.Entity("Domain.Entidades.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Anio")
                        .HasColumnType("int");

                    b.Property<string>("Escuela")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Seccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Turno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("Domain.Entidades.DiaNoLaborable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DiaNoLaborable");
                });

            modelBuilder.Entity("Domain.Entidades.EstadoAsistencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observaciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EstadoAsistencia");
                });

            modelBuilder.Entity("Domain.Entidades.Estudiante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApellidoNombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Apodo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CursoId")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nacionalidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Promedio")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("Estudiante");
                });

            modelBuilder.Entity("Domain.Entidades.EstudianteEvaluacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Calificacion")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("EstudianteId")
                        .HasColumnType("int");

                    b.Property<int>("EvaluacionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstudianteId");

                    b.HasIndex("EvaluacionId");

                    b.ToTable("EstudianteEvaluacion");
                });

            modelBuilder.Entity("Domain.Entidades.EstudianteObservaciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EstudianteId")
                        .HasColumnType("int");

                    b.Property<string>("Observacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ObservacionesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstudianteId");

                    b.HasIndex("ObservacionesId");

                    b.ToTable("EstudianteObservaciones");
                });

            modelBuilder.Entity("Domain.Entidades.EstudiantePeriodo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Calificacion")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("EstudianteId")
                        .HasColumnType("int");

                    b.Property<int>("PeriodoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstudianteId");

                    b.HasIndex("PeriodoId");

                    b.ToTable("EstudiantePeriodo");
                });

            modelBuilder.Entity("Domain.Entidades.Evaluacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Evaluacion");
                });

            modelBuilder.Entity("Domain.Entidades.Observaciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Fechas")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Observaciones");
                });

            modelBuilder.Entity("Domain.Entidades.Periodo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Fechas")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Periodo");
                });

            modelBuilder.Entity("Domain.Entidades.Recordatorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaExpiracion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("Recordatorio");
                });

            modelBuilder.Entity("Domain.Entidades.Asistencia", b =>
                {
                    b.HasOne("Domain.Entidades.EstadoAsistencia", "EstadoAsistencia")
                        .WithMany("Asistencia")
                        .HasForeignKey("EstadoAsistenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entidades.Estudiante", "Estudiante")
                        .WithMany("Asistencia")
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoAsistencia");

                    b.Navigation("Estudiante");
                });

            modelBuilder.Entity("Domain.Entidades.Estudiante", b =>
                {
                    b.HasOne("Domain.Entidades.Curso", null)
                        .WithMany("Estudiante")
                        .HasForeignKey("CursoId");
                });

            modelBuilder.Entity("Domain.Entidades.EstudianteEvaluacion", b =>
                {
                    b.HasOne("Domain.Entidades.Estudiante", "Estudiante")
                        .WithMany("AlumnoEvaluacion")
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entidades.Evaluacion", "Evaluacion")
                        .WithMany("EstudianteEvaluacion")
                        .HasForeignKey("EvaluacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estudiante");

                    b.Navigation("Evaluacion");
                });

            modelBuilder.Entity("Domain.Entidades.EstudianteObservaciones", b =>
                {
                    b.HasOne("Domain.Entidades.Estudiante", "Estudiante")
                        .WithMany("AlumnoObservaciones")
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entidades.Observaciones", "Observaciones")
                        .WithMany("AlumnoObservaciones")
                        .HasForeignKey("ObservacionesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estudiante");

                    b.Navigation("Observaciones");
                });

            modelBuilder.Entity("Domain.Entidades.EstudiantePeriodo", b =>
                {
                    b.HasOne("Domain.Entidades.Estudiante", "Estudiante")
                        .WithMany("AlumnoPeriodo")
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entidades.Periodo", "Periodo")
                        .WithMany("AlumnoPeriodo")
                        .HasForeignKey("PeriodoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estudiante");

                    b.Navigation("Periodo");
                });

            modelBuilder.Entity("Domain.Entidades.Recordatorio", b =>
                {
                    b.HasOne("Domain.Entidades.Curso", "Curso")
                        .WithMany("Recordatorio")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("Domain.Entidades.Curso", b =>
                {
                    b.Navigation("Estudiante");

                    b.Navigation("Recordatorio");
                });

            modelBuilder.Entity("Domain.Entidades.EstadoAsistencia", b =>
                {
                    b.Navigation("Asistencia");
                });

            modelBuilder.Entity("Domain.Entidades.Estudiante", b =>
                {
                    b.Navigation("AlumnoEvaluacion");

                    b.Navigation("AlumnoObservaciones");

                    b.Navigation("AlumnoPeriodo");

                    b.Navigation("Asistencia");
                });

            modelBuilder.Entity("Domain.Entidades.Evaluacion", b =>
                {
                    b.Navigation("EstudianteEvaluacion");
                });

            modelBuilder.Entity("Domain.Entidades.Observaciones", b =>
                {
                    b.Navigation("AlumnoObservaciones");
                });

            modelBuilder.Entity("Domain.Entidades.Periodo", b =>
                {
                    b.Navigation("AlumnoPeriodo");
                });
#pragma warning restore 612, 618
        }
    }
}
