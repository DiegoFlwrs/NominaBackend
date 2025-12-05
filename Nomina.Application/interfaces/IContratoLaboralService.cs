using Nomina.Application.DTOs;
using Nomina.Domain.Entities;
using Nomina.Domain.ReadModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nomina.Application.Interfaces
{
    public interface IContratoLaboralService
    {
        Task<IEnumerable<ContratoView>> ConsultarContratos();
        Task<ContratoLaboral> ObtenerContrato(string codigo);
        Task<string> RegistrarContrato(RegistroContratoDto dto);
        Task ModificarContrato(ContratoLaboralDto dto);
        Task EliminarContrato(string contratoCodigo);
        Task RegistrarHistorial(HistorialContrato historial);
        Task SuspenderContrato(string contratoCodigo, string nuevoEstado, string motivo);
        Task<IEnumerable<ContratoResumen>> ListarContratosPorTipo();
        Task<IEnumerable<ContratoResumen>> ListarContratosPorModalidad();
        Task<IEnumerable<ContratoResumen>> ListarContratosPorJornada();
        Task<IEnumerable<ContratoResumen>> ListarContratosPorEstado();
        Task<IEnumerable<HistorialDetalle>> ListarHistorialDetalles();
        Task<IEnumerable<object>> ListarEmpleadosSinContrato();
    }
}
