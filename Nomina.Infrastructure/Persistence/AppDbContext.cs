using Microsoft.EntityFrameworkCore;
using Nomina.Domain.Entities;

namespace Nomina.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PeriodosNomina> PeriodosNomina { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }

        public DbSet<ContratoLaboral> ContratosLaborales { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<HistorialContrato> HistorialContratos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PeriodosNomina>(entity =>
            {
                entity.HasKey(e => e.PeriodoCodigo);
                entity.Property(e => e.PeriodoCodigo).HasMaxLength(10).IsRequired();
                entity.Property(e => e.PeriodoTipo).HasMaxLength(20);
                entity.Property(e => e.PeriodoEstado).HasMaxLength(1);
            });

            modelBuilder.Entity<Departamentos>(entity =>
            {
                entity.HasKey(e => e.DepartamentoCodigo);
            });

            modelBuilder.Entity<ContratoLaboral>(entity =>
            {
                entity.HasKey(e => e.ContratoCodigo);
                entity.Property(e => e.ContratoCodigo).HasMaxLength(5);
                entity.Property(e => e.EmpleadoCodigo).HasMaxLength(5).IsRequired();
                entity.Property(e => e.ContratoEstado).HasMaxLength(1).HasDefaultValue("A");
                entity.ToTable("ContratosLaborales");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.EmpleadoCodigo);
                entity.Property(e => e.EmpleadoCodigo).HasMaxLength(5);
                entity.Property(e => e.EmpleadoNombre).HasMaxLength(100);
                entity.Property(e => e.EmpleadoApellido).HasMaxLength(100);
                entity.Property(e => e.EmpleadoEstado).HasMaxLength(20);
                entity.ToTable("Empleados");
            });

            modelBuilder.Entity<HistorialContrato>(entity =>
            {
                entity.HasKey(e => e.HistorialCodigo);
                entity.Property(e => e.HistorialCodigo).HasMaxLength(5);
                entity.ToTable("HistorialContratos");
            });
        }
    }
}
