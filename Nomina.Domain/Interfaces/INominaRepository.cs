using Nomina.Domain.Entities;
using Nomina.Domain.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.Interfaces
{
    public interface INominaRepository
    {
        //Task<bool> ProcesarNominaPorPeriodoAsync(int idPeriodo, DateTime fechaProceso, int usuarioId);
        Task<IEnumerable<NominaView>> ConsultarNominasAsync( int? periodoAnio, int? periodoMes, string nominaEstado, string? empleadoNombre,
            string? empleadoApellido, string? departamentoCodigo, int pageNumber, int pageSize);

        Task<IEnumerable<PeriodosNomina>> ObtenerPeriodosAsync();
    }
}
