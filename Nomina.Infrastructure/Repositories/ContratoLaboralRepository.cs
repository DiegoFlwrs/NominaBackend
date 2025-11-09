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

            var Mostrar = contratos.Select(c => new ContratoLaboral
            {
                ContratoCodigo = c.ContratoCodigo.Trim(),
                EmpleadoCodigo = c.EmpleadoCodigo.Trim(),
                TipoContratoCodigo = c.TipoContratoCodigo?.Trim(),
                ModalidadCodigo = c.ModalidadCodigo?.Trim(),
                JornadaCodigo = c.JornadaCodigo?.Trim(),
                UsuarioCodigo = c.UsuarioCodigo?.Trim(),
                ContratoFechaInicio = c.ContratoFechaInicio,
                ContratoFechaFin = c.ContratoFechaFin,
                ContratoSalario = c.ContratoSalario,
                ContratoBonificacion = c.ContratoBonificacion,
                ContratoDescuento = c.ContratoDescuento,
                ContratoEstado = c.ContratoEstado.Trim(),
                ContratoFechaRegistro = c.ContratoFechaRegistro,
                ContratoFechaModificacion = c.ContratoFechaModificacion
            }).ToList();

            return Mostrar;
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
            ContratoLaboralRules.ContratoProximoAVencer(contrato);
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
                new SqlParameter("@ContratoDescuento", contrato.ContratoDescuento ?? 0),
                new SqlParameter("@ContratoEstado", contrato.ContratoEstado ?? (object)DBNull.Value)
            };
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC dbo.ModificarContratoLaboral @ContratoCodigo, @TipoContratoCodigo, @ModalidadCodigo, @JornadaCodigo, @UsuarioCodigo, @ContratoFechaInicio, @ContratoFechaFin, @ContratoSalario, @ContratoBonificacion, @ContratoDescuento, @ContratoEstado",
                parametros);
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
            ContratoLaboralRules.ValidarMotivoHistorial(historial.HistorialMotivo);
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

        public async Task<IEnumerable<ResumenEmpleado>> ListarEmpleadosCodigo()
        {
            return await _context.Set<ResumenEmpleado>()
                .FromSqlRaw("EXEC ListarEmpleadosCodigo")
                .ToListAsync();
        }
        public async Task SuspenderContrato(string contratoCodigo, string nuevoEstado, string motivo)
        {
            var contrato = await _context.ContratosLaborales
         .FirstOrDefaultAsync(c => c.ContratoCodigo.Trim() == contratoCodigo.Trim());
            if (contrato == null)
                throw new KeyNotFoundException("Contrato no encontrado.");
            ContratoLaboralRules.ValidarReactivacion(contrato.ContratoEstado, nuevoEstado);
            string eventoCodigo;
            string detalle;
            if (contrato.ContratoEstado.Trim() == "S" && nuevoEstado.Trim() == "A")
            {
                eventoCodigo = "0002";
                detalle = "Contrato reactivado por usuario";
            }
            else if (contrato.ContratoEstado.Trim() == "A" && nuevoEstado.Trim() == "S")
            {
                eventoCodigo = "0003";
                detalle = "Contrato suspendido por usuario";
            }
            else
            {
                throw new InvalidOperationException("No se puede cambiar a este estado desde el estado actual.");
            }
            var ultimoHistorial = await _context.Set<HistorialContrato>()
                .OrderByDescending(h => h.HistorialCodigo)
                .FirstOrDefaultAsync();
            int nuevoNumero = 1;
            if (ultimoHistorial != null && int.TryParse(ultimoHistorial.HistorialCodigo, out int ultimoNumero))
                nuevoNumero = ultimoNumero + 1;
            string nuevoHistorialCodigo = nuevoNumero.ToString("D5");
            var historial = new HistorialContrato
            {
                HistorialCodigo = nuevoHistorialCodigo,
                ContratoCodigo = contrato.ContratoCodigo,
                EventoCodigo = eventoCodigo,
                HistorialMotivo = motivo,
                HistorialDetalle = detalle,
                HistorialFecha = DateTime.Now
            };
            await RegistrarHistorial(historial);
            var parameters = new[]
            {
        new SqlParameter("@ContratoCodigo", contratoCodigo),
        new SqlParameter("@NuevoEstado", nuevoEstado.Trim())
    };
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC SuspenderContratoLaboral @ContratoCodigo, @NuevoEstado",
                parameters
            );
        }
    }
}
