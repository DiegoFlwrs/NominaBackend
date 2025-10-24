using Nomina.Application.DTOs;
using Nomina.Application.DTOs.NominaPeriodo;
using Nomina.Domain.Entities;
using Nomina.Domain.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Application.interfaces
{
    public interface INominaService
    {
        Task<(IEnumerable<NominaView> Nominas, int TotalRows)> ProcesarNominaAsync(NominaFiltroRequest request);
        Task<IEnumerable<int>> ObtenerAniosAsync();
        Task<IEnumerable<int>> ObtenerMesesAsync();
        Task<IEnumerable<PeriodoDTO>> ObtenerPeriodoAsync();
        Task<IEnumerable<DepartamentoDTO>> ObtenerDepartamentosAsync();
        Task<IEnumerable<ContratoDTO>> ObtenerContratoAsync();
        Task CrearNominaAsync(NominaRequest request);

        Task ActualizarNominaAsync(NominaRequest request);
    }
}
