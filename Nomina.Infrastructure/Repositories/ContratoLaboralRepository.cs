using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Nomina.Domain.Entities;
using Nomina.Domain.Interfaces;
using Nomina.Domain.Rules;
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
            var contratos = await _context.ContratosLaborales
                .FromSqlRaw("EXEC ConsultarContratosLaborales")
                .AsNoTracking()
                .ToListAsync();

            return contratos;
        }

        public async Task InsertarContrato(ContratoLaboral contrato)
        {
            ContratoLaboralRules.ValidarCoherenciaGeneral(contrato);
            ContratoLaboralRules.ValidarFechaInicio(contrato);
            bool existeContratoVigente = await _context.ContratosLaborales
            .AnyAsync(c => c.EmpleadoCodigo == contrato.EmpleadoCodigo && c.ContratoEstado.Trim() == "A");
            ContratoLaboralRules.ValidarContratoDuplicado(existeContratoVigente);

            var parametros = new[]
            {
        new SqlParameter("@ContratoCodigo", contrato.ContratoCodigo),
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

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.InsertarContratoLaboral @ContratoCodigo, @EmpleadoCodigo, @TipoContratoCodigo, @ModalidadCodigo, @JornadaCodigo, @UsuarioCodigo, @ContratoFechaInicio, @ContratoFechaFin, @ContratoSalario, @ContratoBonificacion, @ContratoDescuento",
                parametros
            );
        }

        public async Task ModificarContrato(ContratoLaboral contrato)
        {
            ContratoLaboralRules.ValidarEdicionPorEstado(contrato.ContratoEstado);
            ContratoLaboralRules.ValidarCoherenciaGeneral(contrato);
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

        public async Task RegistrarHistorial(HistorialContrato historial)
        {
            var parametros = new[]
            {
                new SqlParameter("@HistorialCodigo", historial.HistorialCodigo),
                new SqlParameter("@ContratoCodigo", historial.ContratoCodigo),
                new SqlParameter("@EventoCodigo", historial.EventoCodigo),
                new SqlParameter("@HistorialMotivo", historial.HistorialMotivo ?? (object)DBNull.Value),
                new SqlParameter("@HistorialDetalle", historial.HistorialDetalle ?? (object)DBNull.Value),
                new SqlParameter("@HistorialFecha", historial.HistorialFecha)
            };

            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.RegistrarHistorialContrato @HistorialCodigo, @ContratoCodigo, @EventoCodigo, @HistorialMotivo, @HistorialDetalle, @HistorialFecha",
                parametros
            );
        }

        public async Task<IEnumerable<ContratoResumen>> ListarContratosPorTipo()
        {
            return await _context.ContratosResumen
                .FromSqlRaw("EXEC dbo.ListarContratosPorTipo")
                .ToListAsync();
        }

        public async Task<IEnumerable<ContratoResumen>> ListarContratosPorModalidad()
        {
            return await _context.ContratosResumen
                .FromSqlRaw("EXEC dbo.ListarContratosPorModalidad")
                .ToListAsync();
        }

        public async Task<IEnumerable<ContratoResumen>> ListarContratosPorJornada()
        {
            return await _context.ContratosResumen
                .FromSqlRaw("EXEC dbo.ListarContratosPorJornada")
                .ToListAsync();
        }

        public async Task<IEnumerable<ContratoResumen>> ListarContratosPorEstado()
        {
            return await _context.ContratosResumen
                .FromSqlRaw("EXEC dbo.ListarContratosPorEstado")
                .ToListAsync();
        }
        public async Task<IEnumerable<HistorialDetalle>> ListarHistorialDetalles()
        {
            return await _context.Set<HistorialDetalle>()
                .FromSqlRaw("EXEC dbo.ConsultarHistorialDetalle")
                .ToListAsync();
        }

    }
}
