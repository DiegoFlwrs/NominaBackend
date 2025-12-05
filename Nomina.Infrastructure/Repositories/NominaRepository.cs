using Microsoft.Data.SqlClient;
using System.Data;
using Nomina.API.Exceptions;
using Nomina.Domain.Interfaces;
using Nomina.Domain.ReadModels;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Nomina.Domain.Entities;
using Nomina.Infrastructure.Persistence;
using Nomina.Domain.Exceptions;

namespace Nomina.Infrastructure.Repositories
{
    public class NominaRepository : INominaRepository
    {
        private readonly string _connectionString;
        private readonly AppDbContext _context;

        public NominaRepository(AppDbContext context, string connectionString)
        {
            _connectionString = connectionString;
            _context = context;
        }

        public async Task<IEnumerable<NominaView>> ConsultarNominasAsync(string codigoPeriodo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    var parameters = new
                    {
                        CodigoPeriodo = codigoPeriodo
                    };

                    var nominas = await con.QueryAsync<NominaView>(
                        "ConsultarNominas",
                        parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return nominas;
                }
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


        public async Task<IEnumerable<PeriodoNomina>> ObtenerPeriodosAsync()
        {
            try
            {
                return await _context.PeriodosNomina
                .OrderByDescending(p => p.PeriodoAnio)
                .ThenByDescending(p => p.PeriodoMes)
                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new AppException("APP_ERROR: " + ex.Message, ex);
            }
        }

        public async Task<IEnumerable<Departamento>> ObtenerDepartamentosAsync()
        {
            try
            {
                return await _context.Departamentos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new AppException("APP_ERROR: " + ex.Message, ex);
            }
        }

        public async Task<IEnumerable<ContratoLaboral>> ObtenerContratoAsync()
        {
            try
            {
                return await _context.ContratosLaborales
                    .Include(c => c.Empleado).
                    ToListAsync();
            }
            catch (Exception ex)
            {
                throw new AppException("APP_ERROR: " + ex.Message, ex);
            }
        }


        public async Task InsertarNominaAsync( string nominaCodigo, string periodoCodigo, string contratoCodigo, int nominaHorasExtras, decimal nominaMontoHorasExtras, decimal nominaBonificacion,
            decimal nominaTotalIngresos, decimal nominaTotalDescuentos, decimal nominaSueldoNeto, decimal nominaAsignacionFamiliar, decimal nominaDescuentoPension, 
            decimal nominaDescuentoIR5ta, decimal nominaAporteEssalud, decimal nominaOtrosDescuentos, char nominaEstado = 'A')
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    var parameters = new
                    {
                        NominaCodigo = nominaCodigo,
                        PeriodoCodigo = periodoCodigo,
                        ContratoCodigo = contratoCodigo,
                        NominaHorasExtras = nominaHorasExtras,
                        NominaMontoHorasExtras = nominaMontoHorasExtras,
                        NominaBonificacion = nominaBonificacion,
                        NominaAsignacionFamiliar = nominaAsignacionFamiliar,
                        NominaTotalIngresos = nominaTotalIngresos,
                        NominaDescuentoPension = nominaDescuentoPension,
                        NominaDescuentoIR5ta = nominaDescuentoIR5ta,
                        NominaAporteEssalud = nominaAporteEssalud,
                        NominaOtrosDescuentos = nominaOtrosDescuentos,
                        NominaTotalDescuentos = nominaTotalDescuentos,
                        NominaSueldoNeto = nominaSueldoNeto,
                        NominaEstado = nominaEstado
                    };

                    await con.ExecuteAsync(
                        "InsertarNomina",
                        parameters,
                        commandType: System.Data.CommandType.StoredProcedure
                    );
                }
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


        public async Task<ContratoLaboral?> ObtenerContratoConEmpleadoAsync(string contratoCodigo)
        {
            try
            {
                return await _context.ContratosLaborales
                    .Include(c => c.Empleado)
                    .FirstOrDefaultAsync(c => c.ContratoCodigo == contratoCodigo && c.ContratoEstado == "A");
            }
            catch (Exception ex)
            {
                throw new AppException("APP_ERROR: " + ex.Message, ex);
            }
        }

        public async Task<ContratoLaboral?> ObtenerContratosAsync()
        {
            try
            {
                var hoy = DateTime.Now.Date;

                return await _context.ContratosLaborales
                    .Include(c => c.Empleado)
                    .FirstOrDefaultAsync(c => c.ContratoEstado == "A" &&
                        c.ContratoFechaInicio <= hoy &&
                        c.ContratoFechaFin >= hoy
                    );
            }
            catch (Exception ex)
            {
                throw new AppException("APP_ERROR: " + ex.Message, ex);
            }
        }

        public async Task<IEnumerable<ParametroSistema>> ObtenerParametrosSistemaAsync()
        {
            try
            {
                return await _context.ParametrosSistema
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new AppException("APP_ERROR: " + ex.Message, ex);
            }
        }

        public async Task<string?> ObtenerUltimoCodigoNominaAsync()
        {
            try
            {
                var ultimo = await _context.Nominas
                    .OrderByDescending(n => n.NominaCodigo)
                    .Select(n => n.NominaCodigo)
                    .FirstOrDefaultAsync();

                return ultimo;
            }
            catch (Exception ex)
            {
                throw new AppException("APP_ERROR: " + ex.Message, ex);
            }
        }

        public async Task<IEnumerable<ConceptoNomina>> ObtenerConceptosPorContratoYPeriodoAsync(string contratoCodigo, string periodoCodigo)
        {
            try
            {
                return await _context.ConceptosNomina
                    .Where(c => c.ContratoCodigo == contratoCodigo && c.PeriodoCodigo == periodoCodigo)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new AppException("APP_ERROR: " + ex.Message, ex);
            }
        }

        public async Task ActualizarPeriodoAsync(PeriodoNomina periodo)
        {
            try
            {
                _context.PeriodosNomina.Update(periodo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new AppException("APP_ERROR: " + ex.Message, ex);
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new AppException("APP_ERROR: " + ex.Message, ex);
            }
        }

    }
}
