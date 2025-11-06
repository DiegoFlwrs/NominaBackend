using Microsoft.EntityFrameworkCore;
using Nomina.Domain.Entities;

namespace Nomina.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // 🔹 DbSets (una por tabla)
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<JornadaLaboral> JornadasLaborales { get; set; }
        public DbSet<ModalidadPago> ModalidadesPago { get; set; }
        public DbSet<TipoContrato> TiposContrato { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ContratoLaboral> ContratosLaborales { get; set; }
        public DbSet<EventoContrato> EventosContrato { get; set; }
        public DbSet<HistorialContrato> HistorialContratos { get; set; }
        public DbSet<PeriodoNomina> PeriodosNomina { get; set; }
        public DbSet<Nominas> Nominas { get; set; }
        public DbSet<DescuentoAdicional> DescuentosAdicionales { get; set; }
        public DbSet<ParametroSistema> ParametrosSistema { get; set; }
        public DbSet<ContratoResumen> ContratosResumen { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ================================
            // 🔸 Configuración de tablas y claves
            // ================================

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.ToTable("Cargos", "dbo");
                entity.HasKey(e => e.CargoCodigo);
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.ToTable("Departamentos", "dbo");
                entity.HasKey(e => e.DepartamentoCodigo);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("Empleados", "dbo");
                entity.HasKey(e => e.EmpleadoCodigo);

                entity.HasOne(e => e.Departamento)
                    .WithMany(d => d.Empleados)
                    .HasForeignKey(e => e.DepartamentoCodigo)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Cargo)
                    .WithMany(c => c.Empleados)
                    .HasForeignKey(e => e.CargoCodigo)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<JornadaLaboral>(entity =>
            {
                entity.ToTable("JornadasLaborales", "dbo");
                entity.HasKey(e => e.JornadaCodigo);
            });

            modelBuilder.Entity<ModalidadPago>(entity =>
            {
                entity.ToTable("ModalidadesPago", "dbo");
                entity.HasKey(e => e.ModalidadCodigo);
            });

            modelBuilder.Entity<TipoContrato>(entity =>
            {
                entity.ToTable("TiposContrato", "dbo");
                entity.HasKey(e => e.TipoContratoCodigo);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios", "dbo");
                entity.HasKey(e => e.UsuarioCodigo);
            });

            modelBuilder.Entity<ContratoLaboral>(entity =>
            {
                entity.ToTable("ContratosLaborales", "dbo");
                entity.HasKey(e => e.ContratoCodigo);

                entity.HasOne(e => e.Empleado)
                    .WithMany(emp => emp.ContratosLaborales)
                    .HasForeignKey(e => e.EmpleadoCodigo)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.TipoContrato)
                    .WithMany(t => t.ContratosLaborales)
                    .HasForeignKey(e => e.TipoContratoCodigo)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Modalidad)
                    .WithMany(m => m.ContratosLaborales)
                    .HasForeignKey(e => e.ModalidadCodigo)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Jornada)
                    .WithMany(j => j.ContratosLaborales)
                    .HasForeignKey(e => e.JornadaCodigo)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Usuario)
                    .WithMany(u => u.ContratosLaborales)
                    .HasForeignKey(e => e.UsuarioCodigo)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<EventoContrato>(entity =>
            {
                entity.ToTable("EventosContrato", "dbo");
                entity.HasKey(e => e.EventoCodigo);
            });

            modelBuilder.Entity<PeriodoNomina>(entity =>
            {
                entity.ToTable("PeriodosNomina", "dbo");
                entity.HasKey(e => e.PeriodoCodigo);
            });

            modelBuilder.Entity<Nominas>(entity =>
            {
                entity.ToTable("Nominas", "dbo");
                entity.HasKey(e => e.NominaCodigo);

                entity.HasOne(n => n.Contrato)
                    .WithMany(c => c.Nominas)
                    .HasForeignKey(n => n.ContratoCodigo)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(n => n.Periodo)
                    .WithMany(p => p.Nominas)
                    .HasForeignKey(n => n.PeriodoCodigo)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<DescuentoAdicional>(entity =>
            {
                entity.ToTable("DescuentosAdicionales", "dbo");
                entity.HasKey(e => e.DescuentoCodigo);

                entity.HasOne(d => d.Nomina)
                    .WithMany(n => n.DescuentosAdicionales)
                    .HasForeignKey(d => d.NominaCodigo)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ParametroSistema>(entity =>
            {
                entity.ToTable("ParametrosSistema", "dbo");
                entity.HasKey(e => e.ParametroCodigo);
            });

            modelBuilder.Entity<HistorialContrato>(entity =>
            {
                entity.HasKey(e => e.HistorialCodigo);
                entity.Property(e => e.HistorialCodigo).HasMaxLength(5);
                entity.ToTable("HistorialContratos");
            });
            modelBuilder.Entity<ContratoResumen>().HasNoKey();
            modelBuilder.Entity<HistorialDetalle>().HasNoKey();
        }

    }
}
