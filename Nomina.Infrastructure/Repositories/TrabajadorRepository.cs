using Nomina.Domain.Entities;
using Nomina.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Infrastructure.Repositories
{
    public class TrabajadorRepository : iTrabajadorRepository
    {
        private readonly string _connectionString;

        public TrabajadorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Trabajador>> ObtenerTrabajadoresActivosAsync()
        {
            var lista = new List<Trabajador>();

            try 
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ListarTrabajadoresActivos", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        await con.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                lista.Add(new Trabajador
                                {
                                    IdTrabajador = (int)reader["IdTrabajador"],
                                    Nombres = reader["Nombres"].ToString(),
                                    Apellidos = reader["Apellidos"].ToString(),
                                    DNI = reader["DNI"].ToString(),
                                    FechaIngreso = Convert.ToDateTime(reader["FechaIngreso"]),
                                    Estado = Convert.ToBoolean(reader["Estado"]),
                                    SistemaPension = reader["SistemaPension"].ToString(),
                                    TieneHijos = Convert.ToBoolean(reader["TieneHijos"])
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("DB_ERROR: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error inesperado al consultar los trabajadores.", ex);
            }

            return lista;
        }
    }
}
