using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nomina.API.Exceptions;
using Nomina.Domain.Interfaces;
using Nomina.Domain.ReadModels;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Nomina.Domain.Entities;
using Nomina.Infrastructure.Persistence;

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

        public async Task<(IEnumerable<NominaView> Nominas, int TotalRows)> ConsultarNominasAsync(int? periodoAnio, int? periodoMes, string nominaEstado, string? empleadoNombre,
            string? empleadoApellido, string? departamentoCodigo, int pageNumber, int pageSize)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    var parameters = new
                    {
                        PeriodoAnio = periodoAnio,
                        PeriodoMes = periodoMes,
                        NominaEstado = nominaEstado,
                        EmpleadoNombre = empleadoNombre,
                        EmpleadoApellido = empleadoApellido,
                        DepartamentoCodigo = departamentoCodigo,
                        PageNumber = pageNumber,
                        PageSize = pageSize
                    };

                    using var multi = await con.QueryMultipleAsync("ConsultarNominas", parameters, commandType: System.Data.CommandType.StoredProcedure);

                    var nominas = await multi.ReadAsync<NominaView>();
                    var totalRows = await multi.ReadFirstAsync<int>();

                    return (nominas, totalRows);
                }
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
                throw new Exception("APP_ERROR: " + ex.Message);
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
                throw new Exception("APP_ERROR: " + ex.Message);
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
                throw new Exception("APP_ERROR: " + ex.Message);
            }
        }


        public async Task InsertarNominaAsync( string nominaCodigo, string periodoCodigo, string contratoCodigo, int nominaHorasExtras, decimal nominaBonificacion,
            decimal nominaDescuentos, decimal nominaTotalIngresos, decimal nominaTotalDescuentos, decimal nominaSueldoNeto, char nominaEstado = 'A')
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
                        NominaBonificacion = nominaBonificacion,
                        NominaDescuentos = nominaDescuentos,
                        NominaTotalIngresos = nominaTotalIngresos,
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
                throw new Exception("APP_ERROR: " + ex.Message);
            }
        }

        public async Task ActualizarNominaAsync( string nominaCodigo, int nominaHorasExtras, decimal nominaBonificacion, decimal nominaDescuentos, decimal nominaTotalIngresos,
        decimal nominaTotalDescuentos, decimal nominaSueldoNeto, char nominaEstado = 'A')
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    var parameters = new
                    {
                        NominaCodigo = nominaCodigo,
                        NominaHorasExtras = nominaHorasExtras,
                        NominaBonificacion = nominaBonificacion,
                        NominaDescuentos = nominaDescuentos,
                        NominaTotalIngresos = nominaTotalIngresos,
                        NominaTotalDescuentos = nominaTotalDescuentos,
                        NominaSueldoNeto = nominaSueldoNeto,
                        NominaEstado = nominaEstado
                    };

                    await con.ExecuteAsync(
                        "ModificarNomina",
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
                throw new Exception("APP_ERROR: " + ex.Message);
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
                throw new Exception("APP_ERROR: " + ex.Message);
            }
        }

    }
}
