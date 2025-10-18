using Nomina.Application.DTOs;
using Nomina.Application.interfaces;
using Nomina.Domain.Entities;
using Nomina.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Application.Services
{
    public class TrabajadorService : ITrabajadorService
    {
        private readonly iTrabajadorRepository _repository;

        public TrabajadorService(iTrabajadorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TrabajadorDTO>> ListarActivosAsync()
        {
            var trabajadores = await _repository.ObtenerTrabajadoresActivosAsync();

            if (trabajadores == null || !trabajadores.Any())
            { 
                throw new Exception("No existen trabajadores activos.");
            }

            var resultado = trabajadores.Select(t => new TrabajadorDTO
            {
                Nombres = t.Nombres,
                Apellidos = t.Apellidos,
                DNI = t.DNI,
                FechaIngreso = t.FechaIngreso,
                SistemaPension = t.SistemaPension
            });

            return resultado;
        }
    }
}
