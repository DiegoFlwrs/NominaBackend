using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Nomina.Domain.Interfaces;
using Nomina.Domain.ReadModels;
using Dapper;

namespace Nomina.Infrastructure.Repositories
{
    public class ReporteNominaRepository : IReporteNominaRepository
    {
        private readonly string _connectionString;

        public ReporteNominaRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public async Task<List<ReporteNominaView>> ObtenerReporteNominaAsync(
            string? PeriodoCodigo = null,
            string? departamentoCodigo = null,
            string? cargoCodigo = null,
            string? tipoContratoCodigo = null
        )
        {
            const string spName = "[dbo].[GenerarReporteNominaPorPeriodo2]";

            var parameters = new DynamicParameters();

            parameters.Add("@PeriodoCodigo", PeriodoCodigo);
            parameters.Add("@DepartamentoCodigo", (object)departamentoCodigo ?? DBNull.Value, DbType.String, size: 10);
            parameters.Add("@CargoCodigo", (object)cargoCodigo ?? DBNull.Value, DbType.String, size: 10);
            parameters.Add("@TipoContratoCodigo", (object)tipoContratoCodigo ?? DBNull.Value, DbType.String, size: 10);

            using (var connection = new SqlConnection(_connectionString))
            {
                var reporteData = await connection.QueryAsync<ReporteNominaView>(
                    spName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return reporteData.ToList();
            }
        }
    }
}