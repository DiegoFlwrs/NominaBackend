using Nomina.Domain.Entities;
using Nomina.Domain.ReadModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nomina.Domain.Interfaces
{
    public interface IContratoLaboralRepository
    {
        //Task<IEnumerable<ContratoLaboral>> ConsultarContratos();
        Task InsertarContrato(ContratoLaboral contrato);
        Task ModificarContrato(ContratoLaboral contrato);
        Task EliminarContrato(string contratoCodigo);
        Task SuspenderContrato(string contratoCodigo, string nuevoEstado, string motivo);
        Task<bool> ExisteContratoVigente(string empleadoCodigo);
        Task<bool> ExisteEmpleadoActivo(string empleadoCodigo);
        Task<ContratoLaboral?> ObtenerContrato(string contratoCodigo);
        Task RegistrarHistorial(HistorialContrato historial);
        Task<IEnumerable<ContratoResumen>> ListarContratosPorTipo();
        Task<IEnumerable<ContratoResumen>> ListarContratosPorModalidad();
        Task<IEnumerable<ContratoResumen>> ListarContratosPorJornada();
        Task<IEnumerable<ContratoResumen>> ListarContratosPorEstado();
        Task<IEnumerable<HistorialDetalle>> ListarHistorialDetalles();
        Task<IEnumerable<ResumenEmpleado>> ListarEmpleadosCodigo();
        Task<IEnumerable<ContratoView>> ConsultarContratosAsync();
    }
}
