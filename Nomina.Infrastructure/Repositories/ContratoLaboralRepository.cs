using Dapper;
using Microsoft.Data.SqlClient;
using Nomina.Domain.Entities;
using Nomina.Domain.Interfaces;


namespace Nomina.Infrastructure.Repositories
{
    public class ContratoLaboralRepository : IContratoLaboralRepository
    {
        private readonly string _connectionString;

        public ContratoLaboralRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<ContratoLaboral>> ConsultarContratos()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<ContratoLaboral>("SELECT * FROM ContratosLaborales");
        }

        public async Task InsertarContrato(ContratoLaboral contrato)
        {
            if (string.IsNullOrWhiteSpace(contrato.ContratoCodigo))
            {
                contrato.ContratoCodigo = "C" + new Random().Next(100, 999).ToString();
            }

            using var connection = new SqlConnection(_connectionString);

            var sql = @"INSERT INTO ContratosLaborales 
                        (ContratoCodigo, EmpleadoCodigo, TipoContratoCodigo, ModalidadCodigo, JornadaCodigo, UsuarioCodigo, 
                        ContratoFechaInicio, ContratoFechaFin, ContratoSalario, ContratoBonificacion, ContratoDescuento, ContratoEstado)
                        VALUES (@ContratoCodigo, @EmpleadoCodigo, @TipoContratoCodigo, @ModalidadCodigo, @JornadaCodigo, @UsuarioCodigo,
                                @ContratoFechaInicio, @ContratoFechaFin, @ContratoSalario, @ContratoBonificacion, @ContratoDescuento, @ContratoEstado)";

            await connection.ExecuteAsync(sql, contrato);
        }

        public async Task ModificarContrato(ContratoLaboral contrato)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = @"UPDATE ContratosLaborales 
                        SET ContratoFechaInicio=@ContratoFechaInicio, ContratoFechaFin=@ContratoFechaFin, 
                            ContratoSalario=@ContratoSalario, ContratoBonificacion=@ContratoBonificacion, 
                            ContratoDescuento=@ContratoDescuento, ContratoEstado=@ContratoEstado
                        WHERE ContratoCodigo=@ContratoCodigo";
            await connection.ExecuteAsync(sql, contrato);
        }

        public async Task EliminarContrato(string contratoCodigo)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("DELETE FROM ContratosLaborales WHERE ContratoCodigo=@ContratoCodigo", new { ContratoCodigo = contratoCodigo });
        }

        public async Task<bool> ExisteContratoVigente(string empleadoCodigo)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "SELECT COUNT(*) FROM ContratosLaborales WHERE EmpleadoCodigo=@EmpleadoCodigo AND ContratoEstado='A'";
            int count = await connection.ExecuteScalarAsync<int>(query, new { EmpleadoCodigo = empleadoCodigo });
            return count > 0;
        }

        public async Task<bool> ExisteEmpleadoActivo(string empleadoCodigo)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "SELECT COUNT(*) FROM Empleados WHERE EmpleadoCodigo=@EmpleadoCodigo AND EmpleadoEstado='A'";
            int count = await connection.ExecuteScalarAsync<int>(query, new { EmpleadoCodigo = empleadoCodigo });
            return count > 0;
        }

        public async Task<ContratoLaboral?> ObtenerContrato(string contratoCodigo)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<ContratoLaboral>(
                "SELECT * FROM ContratosLaborales WHERE ContratoCodigo=@ContratoCodigo",
                new { ContratoCodigo = contratoCodigo });
        }

        public async Task RegistrarHistorial(string contratoCodigo, string evento, string motivo)
        {
            using var connection = new SqlConnection(_connectionString);
            var historialCodigo = "H" + new Random().Next(100000, 999999).ToString();
            
            await connection.ExecuteAsync(
                "INSERT INTO HistorialContratos (HistorialCodigo, ContratoCodigo, EventoCodigo, HistorialMotivo) VALUES (@HistorialCodigo, @ContratoCodigo, @Evento, @Motivo)",
                new { 
                    HistorialCodigo = historialCodigo,
                    ContratoCodigo = contratoCodigo, 
                    Evento = evento, 
                    Motivo = motivo 
                });
        }
    }
}