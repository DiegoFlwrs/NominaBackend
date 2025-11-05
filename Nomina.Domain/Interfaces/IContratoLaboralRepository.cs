using Nomina.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nomina.Domain.Interfaces
{
    public interface IContratoLaboralRepository
    {
        Task<IEnumerable<ContratoLaboral>> ConsultarContratos();
        Task InsertarContrato(ContratoLaboral contrato);
        Task ModificarContrato(ContratoLaboral contrato);
        Task EliminarContrato(string contratoCodigo);
        Task<bool> ExisteContratoVigente(string empleadoCodigo);
        Task<bool> ExisteEmpleadoActivo(string empleadoCodigo);
        Task<ContratoLaboral?> ObtenerContrato(string contratoCodigo);
        Task RegistrarHistorial(string contratoCodigo, string evento, string motivo);
        Task<IEnumerable<ContratoResumen>> ListarContratosPorTipo();
        Task<IEnumerable<ContratoResumen>> ListarContratosPorModalidad();
        Task<IEnumerable<ContratoResumen>> ListarContratosPorJornada();
        Task<IEnumerable<ContratoResumen>> ListarContratosPorEstado();
    }
}
