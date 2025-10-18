using Nomina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.Interfaces
{
    public interface iTrabajadorRepository
    {
        Task<List<Trabajador>> ObtenerTrabajadoresActivosAsync();
    }
}
