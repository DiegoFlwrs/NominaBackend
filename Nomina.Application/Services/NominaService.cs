using Nomina.API.Exceptions;
using Nomina.Domain.DTOs;
using Nomina.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Application.Services
{
    public class NominaService
    {
        private readonly NominaRepository _repository;

        public NominaService(NominaRepository repository)
        {
            _repository = repository;
        }

        public async Task ProcesarNominaAsync(ProcesarNominaRequest request)
        {
            if (request.FechaProceso > DateTime.Now)
                throw new BusinessException("No se puede procesar una nómina con fecha futura.");

            bool resultado = await _repository.ProcesarNominaPorPeriodoAsync(request);

            if (!resultado)
                throw new NotFoundException("No se pudo procesar la nómina. Verifique los datos o el periodo.");
        }
    }
}
