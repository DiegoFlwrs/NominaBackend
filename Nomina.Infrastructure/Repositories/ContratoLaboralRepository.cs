using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Nomina.Domain.Entities;
using Nomina.Domain.Interfaces;
using Nomina.Infrastructure.Persistence;
using System.Data;

namespace Nomina.Infrastructure.Repositories
{
    public class ContratoLaboralRepository : IContratoLaboralRepository
    {
        private readonly AppDbContext _context;

        public ContratoLaboralRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContratoLaboral>> ConsultarContratos()
        {
            return await _context.ContratosLaborales
                .Include(c => c.Empleado)
                .Include(c => c.TipoContrato)
                .Include(c => c.Modalidad)
                .Include(c => c.Jornada)
                .Include(c => c.Usuario)
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task InsertarContrato(ContratoLaboral contrato)
        {
            var parametros = new[]
            {
                new SqlParameter("@EmpleadoCodigo", contrato.EmpleadoCodigo),
                new SqlParameter("@TipoContratoCodigo", contrato.TipoContratoCodigo ?? (object)DBNull.Value),
                new SqlParameter("@ModalidadCodigo", contrato.ModalidadCodigo ?? (object)DBNull.Value),
                new SqlParameter("@JornadaCodigo", contrato.JornadaCodigo ?? (object)DBNull.Value),
                new SqlParameter("@UsuarioCodigo", contrato.UsuarioCodigo ?? (object)DBNull.Value),
                new SqlParameter("@ContratoFechaInicio", contrato.ContratoFechaInicio ?? DateTime.Now),
                new SqlParameter("@ContratoFechaFin", contrato.ContratoFechaFin ?? (object)DBNull.Value),
                new SqlParameter("@ContratoSalario", contrato.ContratoSalario),
                new SqlParameter("@ContratoBonificacion", contrato.ContratoBonificacion ?? 0),
                new SqlParameter("@ContratoDescuento", contrato.ContratoDescuento ?? 0)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC dbo.InsertarContratoLaboral @EmpleadoCodigo, @TipoContratoCodigo, @ModalidadCodigo, @JornadaCodigo, @UsuarioCodigo, @ContratoFechaInicio, @ContratoFechaFin, @ContratoSalario, @ContratoBonificacion, @ContratoDescuento", parametros);
        }

        public async Task ModificarContrato(ContratoLaboral contrato)
        {
            var parametros = new[]
            {
                new SqlParameter("@ContratoCodigo", contrato.ContratoCodigo),
                new SqlParameter("@TipoContratoCodigo", contrato.TipoContratoCodigo ?? (object)DBNull.Value),
                new SqlParameter("@ModalidadCodigo", contrato.ModalidadCodigo ?? (object)DBNull.Value),
                new SqlParameter("@JornadaCodigo", contrato.JornadaCodigo ?? (object)DBNull.Value),
                new SqlParameter("@UsuarioCodigo", contrato.UsuarioCodigo ?? (object)DBNull.Value),
                new SqlParameter("@ContratoFechaInicio", contrato.ContratoFechaInicio ?? DateTime.Now),
                new SqlParameter("@ContratoFechaFin", contrato.ContratoFechaFin ?? (object)DBNull.Value),
                new SqlParameter("@ContratoSalario", contrato.ContratoSalario),
                new SqlParameter("@ContratoBonificacion", contrato.ContratoBonificacion ?? 0),
                new SqlParameter("@ContratoDescuento", contrato.ContratoDescuento ?? 0)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC dbo.ModificarContratoLaboral @ContratoCodigo, @TipoContratoCodigo, @ModalidadCodigo, @JornadaCodigo, @UsuarioCodigo, @ContratoFechaInicio, @ContratoFechaFin, @ContratoSalario, @ContratoBonificacion, @ContratoDescuento", parametros);
        }

        public async Task EliminarContrato(string contratoCodigo)
        {
            var parametro = new SqlParameter("@ContratoCodigo", contratoCodigo);
            await _context.Database.ExecuteSqlRawAsync("EXEC dbo.EliminarContratoLaboral @ContratoCodigo", parametro);
        }

        public async Task<bool> ExisteContratoVigente(string empleadoCodigo)
        {
            return await _context.ContratosLaborales
                .AnyAsync(c => c.EmpleadoCodigo == empleadoCodigo && c.ContratoEstado == "A");
        }

        public async Task<bool> ExisteEmpleadoActivo(string empleadoCodigo)
        {
            return await _context.Empleados
                .AnyAsync(e => e.EmpleadoCodigo == empleadoCodigo && e.EmpleadoEstado == "A");
        }

        public async Task<ContratoLaboral?> ObtenerContrato(string contratoCodigo)
        {
            return await _context.ContratosLaborales
                .FromSqlRaw("SELECT * FROM dbo.ContratosLaborales WHERE ContratoCodigo = {0}", contratoCodigo)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task RegistrarHistorial(string contratoCodigo, string evento, string motivo)
        {
            var parametros = new[]
            {
                new SqlParameter("@ContratoCodigo", contratoCodigo),
                new SqlParameter("@EventoCodigo", evento),
                new SqlParameter("@Motivo", motivo)
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC dbo.RegistrarHistorialContrato @ContratoCodigo, @EventoCodigo, @Motivo", parametros);
        }
    }
}
