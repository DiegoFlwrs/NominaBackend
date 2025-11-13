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
        Task<(IEnumerable<NominaView> Nominas, int TotalRows)> ConsultarNominasAsync( int? periodoAnio, int? periodoMes, string nominaEstado, string? empleadoNombre,
            string? empleadoApellido, string? departamentoCodigo, int pageNumber, int pageSize);

        Task<IEnumerable<PeriodoNomina>> ObtenerPeriodosAsync();
        Task<IEnumerable<Departamento>> ObtenerDepartamentosAsync();
        Task<IEnumerable<ContratoLaboral>> ObtenerContratoAsync();

        Task InsertarNominaAsync(string nominaCodigo, string periodoCodigo, string contratoCodigo, int nominaHorasExtras, decimal nominaBonificacion,
            decimal nominaDescuentos, decimal nominaTotalIngresos, decimal nominaTotalDescuentos, decimal nominaSueldoNeto, char nominaEstado = 'A');
        Task<ContratoLaboral?> ObtenerContratoConEmpleadoAsync(string contratoCodigo);

        Task<IEnumerable<ParametroSistema>> ObtenerParametrosSistemaAsync();
        Task<string?> ObtenerUltimoCodigoNominaAsync();
        Task<IEnumerable<ConceptoNomina>> ObtenerConceptosPorContratoYPeriodoAsync(string contratoCodigo, string periodoCodigo);
        Task ActualizarPeriodoAsync(PeriodoNomina periodo);
        Task SaveChangesAsync();
    }
}
