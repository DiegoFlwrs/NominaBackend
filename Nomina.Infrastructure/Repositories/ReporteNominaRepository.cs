using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nomina.Domain.Interfaces;
using Nomina.Domain.ReadModels;

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
            DateTime fechaInicio,
            DateTime fechaFin,
            string departamentoCodigo = null,
            string cargoCodigo = null,
            string tipoContratoCodigo = null
        )
        {
            var reporte = new List<ReporteNominaView>();

            const string spName = "[dbo].[GenerarReporteNominaPorPeriodo]";

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(spName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FechaInicio", fechaInicio.Date);
                    command.Parameters.AddWithValue("@FechaFin", fechaFin.Date);

                    command.Parameters.AddWithValue("@DepartamentoCodigo", (object)departamentoCodigo ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CargoCodigo", (object)cargoCodigo ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TipoContratoCodigo", (object)tipoContratoCodigo ?? DBNull.Value);

                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            reporte.Add(new ReporteNominaView
                            {
                                NombreCompleto = reader["NombreCompleto"].ToString(),
                                CargoNombre = reader["CargoNombre"].ToString(),
                                DepartamentoNombre = reader["DepartamentoNombre"].ToString(),
                                FechaIngreso = reader.GetDateTime("FechaIngreso"),
                                SueldoBase = reader.GetDecimal("SueldoBase"),
                                NominaBonificacion = reader.GetDecimal("NominaBonificacion"),
                                NominaDescuentos = reader.GetDecimal("NominaDescuentos"),
                                NominaSueldoNeto = reader.GetDecimal("NominaSueldoNeto"),

                                PeriodoInicio = reader["PeriodoInicio"].ToString(),
                                PeriodoFin = reader["PeriodoFin"].ToString()
                            });
                        }
                    }
                }
            }
            return reporte;
        }
    }
}
