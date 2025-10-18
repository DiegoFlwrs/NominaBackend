using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.Interfaces
{
    public interface INominaRepository
    {
        Task<bool> ProcesarNominaPorPeriodoAsync(int idPeriodo, DateTime fechaProceso, int usuarioId);
    }
}
