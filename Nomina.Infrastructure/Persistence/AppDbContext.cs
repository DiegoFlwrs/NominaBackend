using Microsoft.EntityFrameworkCore;
using Nomina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<PeriodosNomina> PeriodosNomina { get; set; }


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

        }

    }
}
