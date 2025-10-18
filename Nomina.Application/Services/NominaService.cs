using Nomina.API.Exceptions;
using Nomina.Application.DTOs;
using Nomina.Application.interfaces;
using Nomina.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Application.Services
{
    public class NominaService : INominaService
    {
        private readonly INominaRepository _repository;

        public NominaService(INominaRepository repository)
        {
            _repository = repository;
        }

        public async Task ProcesarNominaAsync(ProcesarNominaRequest request)
        {
            if (request.FechaProceso > DateTime.Now)
                throw new BusinessException("No se puede procesar una nómina con fecha futura.");

            bool resultado = await _repository.ProcesarNominaPorPeriodoAsync(
                request.IdPeriodo,
                request.FechaProceso,
                request.UsuarioId
                );

            if (!resultado)
                throw new NotFoundException("No se pudo procesar la nómina. Verifique los datos o el periodo.");
        }
    }
}
