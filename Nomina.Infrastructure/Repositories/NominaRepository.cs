using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nomina.API.Exceptions;
using Nomina.Domain.Interfaces;

namespace Nomina.Infrastructure.Repositories
{
    public class NominaRepository : INominaRepository
    {
        private readonly string _connectionString;

        public NominaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> ProcesarNominaPorPeriodoAsync(int idPeriodo, DateTime fechaProceso, int usuarioId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ProcesarNominaPorPeriodo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdPeriodo", idPeriodo);
                        cmd.Parameters.AddWithValue("@FechaProceso", fechaProceso);
                        cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);

                        await con.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {

                throw new DatabaseException($"Error en la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception("APP_ERROR: "+ ex.Message);
            }
        }
    }
}
