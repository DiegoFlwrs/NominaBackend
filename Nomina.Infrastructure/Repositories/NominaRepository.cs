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

        public async Task<IEnumerable<NominaView>> ConsultarNominasAsync(int? periodoAnio, int? periodoMes, string nominaEstado, string? empleadoNombre,
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

                    var result = await con.QueryAsync<NominaView>("ConsultarNominas", parameters, commandType: System.Data.CommandType.StoredProcedure);

                    return result;
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

        public async Task<IEnumerable<PeriodosNomina>> ObtenerPeriodosAsync()
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

    }
}
