using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Nomina.API.Exceptions;
using Nomina.Domain.Entities;
using Nomina.Domain.Exceptions;
using Nomina.Domain.Interfaces;
using Nomina.Domain.ReadModels;
using Nomina.Domain.Rules;
using Nomina.Infrastructure.Persistence;
using System.Data;

namespace Nomina.Infrastructure.Repositories
{
    public class ContratoLaboralRepository : IContratoLaboralRepository
    {
        private readonly AppDbContext _context;
        private readonly string _connectionString;

        public ContratoLaboralRepository(AppDbContext context, string connectionString)
        {
            _context = context;
            _connectionString = connectionString;
        }
        public async Task<IEnumerable<ContratoView>> ConsultarContratosAsync()
        {
            try
            {
                using var con = new SqlConnection(_connectionString);

                var contratos = await con.QueryAsync<ContratoView>(
                    "ConsultarContratosLaborales",
                    commandType: System.Data.CommandType.StoredProcedure
                );

                return contratos;
            }
            catch (SqlException ex)
            {
                throw new DatabaseException($"Error en la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new AppException("APP_ERROR: " + ex.Message, ex);
            }
        }
        public async Task InsertarContrato(ContratoLaboral contrato)
        {
            try
            {
                contrato.ContratoCodigo = await GenerarCodigoContrato();
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
                    new SqlParameter("@ContratoSalario", contrato.ContratoSalario)
                };

                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC dbo.InsertarContratoLaboral @ContratoCodigo, @EmpleadoCodigo, @TipoContratoCodigo, @ModalidadCodigo, @JornadaCodigo, @UsuarioCodigo, @ContratoFechaInicio, @ContratoFechaFin, @ContratoSalario",
                    parametros
                );
            }
            catch (SqlException ex)
            {
                throw new DatabaseException($"Error al insertar el contrato laboral: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new AppException("APP_ERROR: " + ex.Message, ex);
            }
        }
        public async Task ModificarContrato(ContratoLaboral contrato, string motivo)
        {
            try
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
                    new SqlParameter("@ContratoEstado", contrato.ContratoEstado ?? (object)DBNull.Value)
                };

                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC dbo.ModificarContratoLaboral @ContratoCodigo, @TipoContratoCodigo, @ModalidadCodigo, @JornadaCodigo, @UsuarioCodigo, @ContratoFechaInicio, @ContratoFechaFin, @ContratoSalario, @ContratoEstado",
                    parametros);

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
                    EventoCodigo = "0004",
                    HistorialMotivo = motivo,
                    HistorialDetalle = "Modificacion de contrato",
                    HistorialFecha = DateTime.Now
                };

                await RegistrarHistorial(historial);
            }
            catch (SqlException ex)
            {
                throw new DatabaseException($"Error al modificar el contrato laboral: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new AppException("APP_ERROR: " + ex.Message, ex);
            }
        }

        public async Task EliminarContrato(string contratoCodigo)
        {
            try
            {
                var parametro = new SqlParameter("@ContratoCodigo", contratoCodigo);
                await _context.Database.ExecuteSqlRawAsync("EXEC dbo.EliminarContratoLaboral @ContratoCodigo", parametro);
            }
            catch (SqlException ex)
            {
                throw new DatabaseException($"Error al eliminar el contrato laboral: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new AppException("APP_ERROR: " + ex.Message, ex);
            }
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
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ContratoCodigo.Trim() == contratoCodigo.Trim());
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
        public async Task<string> GenerarCodigoContrato()
        {
            var ultimoCodigo = await _context.ContratosLaborales
                .Where(c => c.ContratoCodigo.StartsWith("CON"))
                .OrderByDescending(c => c.ContratoCodigo)
                .Select(c => c.ContratoCodigo)
                .FirstOrDefaultAsync();

            if (string.IsNullOrEmpty(ultimoCodigo))
            {
                return "CON01";
            }
            else
            {
                string numeroStr = ultimoCodigo.Substring(3, 2);
                int numeroActual = int.Parse(numeroStr);
                numeroActual++;
                return $"CON{numeroActual:D2}";
            }
        }
        public async Task<IEnumerable<ContratoResumen>> ListarContratosPorTipo()
        {
            return await _context.TiposContrato
                .Select(t => new ContratoResumen
                {
                    Codigo = (t.TipoContratoCodigo ?? string.Empty).Trim(),
                    Descripcion = (t.TipoContratoDescripcion ?? string.Empty).Trim()
                })
                .OrderBy(cr => cr.Descripcion)
                .ToListAsync();
        }

        public async Task<IEnumerable<ContratoResumen>> ListarContratosPorModalidad()
        {
            return await _context.ContratosLaborales
                .Where(c => c.ContratoEstado == "A")
                .Join(_context.ModalidadesPago,
                      c => c.ModalidadCodigo,
                      m => m.ModalidadCodigo,
                      (c, m) => new ContratoResumen
                      {
                          Codigo = (c.ModalidadCodigo ?? string.Empty).Trim(),
                          Descripcion = (m.ModalidadDescripcion ?? string.Empty).Trim()
                      })
                .Distinct()
                .OrderBy(cr => cr.Descripcion)
                .ToListAsync();
        }

        public async Task<IEnumerable<ContratoResumen>> ListarContratosPorJornada()
        {
            return await _context.JornadasLaborales
                .Select(j => new ContratoResumen
                {
                    Codigo = (j.JornadaCodigo ?? string.Empty).Trim(),
                    Descripcion = (j.JornadaDescripcion ?? string.Empty).Trim()
                })
                .OrderBy(cr => cr.Descripcion)
                .ToListAsync();
        }

        public async Task<IEnumerable<ContratoResumen>> ListarContratosPorEstado()
        {
            return await _context.ContratosLaborales
                .Select(c => new ContratoResumen
                {
                    Codigo = (c.ContratoEstado ?? string.Empty).Trim(),
                    Descripcion = c.ContratoEstado
                })
                .Distinct()
                .OrderBy(cr => cr.Descripcion)
                .ToListAsync();
        }

        public async Task<IEnumerable<HistorialDetalle>> ListarHistorialDetalles()
        {
            return await _context.HistorialContratos
                .OrderByDescending(h => h.HistorialFecha)
                .Select(h => new HistorialDetalle
                {
                    ContratoCodigo = (h.ContratoCodigo ?? string.Empty).Trim(),
                    Detalle = (h.HistorialDetalle ?? string.Empty).Trim(),
                    Motivo = (h.HistorialMotivo ?? string.Empty).Trim(),
                    HistorialFecha = h.HistorialFecha
                })
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
                detalle = "Reactivacion de contrato";
            }
            else if (contrato.ContratoEstado.Trim() == "A" && nuevoEstado.Trim() == "S")
            {
                eventoCodigo = "0003";
                detalle = "Suspension de contrato";
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
        public async Task<IEnumerable<object>> ListarEmpleadosSinContrato()
        {
            var empleados = await _context.Empleados
                .AsNoTracking()
                .Where(e =>
                    !_context.ContratosLaborales
                        .AsNoTracking()
                        .Any(c =>
                            c.EmpleadoCodigo.Trim() == e.EmpleadoCodigo.Trim() &&
                            (c.ContratoEstado.Trim() == "A" || c.ContratoEstado.Trim() == "S")) 
                )
                .Select(e => new
                {
                    EmpleadoCodigo = e.EmpleadoCodigo.Trim(),
                    EmpleadoNombre = (e.EmpleadoNombre + " " + e.EmpleadoApellido).Trim()
                })
                .ToListAsync();

            return empleados;
        }
    }
}