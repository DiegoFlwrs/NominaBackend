using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Nomina.API.Exceptions;
using Nomina.Domain.Entities;
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
                throw new Exception("APP_ERROR: " + ex.Message);
            }
        }

        public async Task InsertarContrato(ContratoLaboral contrato)
        {
            contrato.ContratoFechaInicio ??= DateTime.Now;
            contrato.ContratoBonificacion ??= 0;
            contrato.ContratoDescuento ??= 0;
            await _context.ContratosLaborales.AddAsync(contrato);
            await _context.SaveChangesAsync();
        }

        public async Task ModificarContrato(ContratoLaboral contrato)
        {
            var contratoBD = await _context.ContratosLaborales
                .FirstOrDefaultAsync(c => c.ContratoCodigo == contrato.ContratoCodigo);

            if (contratoBD == null)
                throw new Exception("El contrato no existe.");
            contratoBD.TipoContratoCodigo = contrato.TipoContratoCodigo;
            contratoBD.ModalidadCodigo = contrato.ModalidadCodigo;
            contratoBD.JornadaCodigo = contrato.JornadaCodigo;
            contratoBD.UsuarioCodigo = contrato.UsuarioCodigo;
            contratoBD.ContratoFechaInicio = contrato.ContratoFechaInicio ?? contratoBD.ContratoFechaInicio;
            contratoBD.ContratoFechaFin = contrato.ContratoFechaFin;
            contratoBD.ContratoSalario = contrato.ContratoSalario;
            contratoBD.ContratoBonificacion = contrato.ContratoBonificacion ?? 0;
            contratoBD.ContratoDescuento = contrato.ContratoDescuento ?? 0;
            contratoBD.ContratoEstado = contrato.ContratoEstado; 
            await _context.SaveChangesAsync();
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
                    Descripcion =
                        c.ContratoEstado == "A" ? "Activo" :
                        c.ContratoEstado == "I" ? "Inactivo" :
                        c.ContratoEstado == "S" ? "Suspendido" :
                        "Finalizado"
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
                    HistorialCodigo = (h.HistorialCodigo ?? string.Empty).Trim(),
                    ContratoCodigo = (h.ContratoCodigo ?? string.Empty).Trim(),
                    Detalle = (h.HistorialMotivo ?? string.Empty).Trim(),
                    HistorialFecha = h.HistorialFecha
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ResumenEmpleado>> ListarEmpleadosCodigo()
        {
            return await _context.Empleados
                .Select(e => new ResumenEmpleado
                {
                    Codigo = e.EmpleadoCodigo.Trim(),
                    EmpleadoNombre = e.EmpleadoNombre + " " + e.EmpleadoApellido
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