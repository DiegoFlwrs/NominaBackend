using Nomina.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nomina.Application.Interfaces
{
    public interface IContratoLaboralService
    {
        Task<IEnumerable<ContratoLaboralDTO>> ConsultarContratos();
        Task RegistrarContrato(ContratoLaboralDTO dto);
        Task ModificarContrato(ContratoLaboralDTO dto);
        Task EliminarContrato(string contratoCodigo);
    }
}
