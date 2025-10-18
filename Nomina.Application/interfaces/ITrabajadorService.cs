using Nomina.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Application.interfaces
{
    public interface ITrabajadorService
    {
        Task<IEnumerable<TrabajadorDTO>> ListarActivosAsync();
    }
}
