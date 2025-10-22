using Nomina.API.Exceptions;
using Nomina.Application.DTOs;
using Nomina.Application.DTOs.NominaPeriodo;
using Nomina.Application.interfaces;
using Nomina.Domain.Entities;
using Nomina.Domain.Interfaces;
using Nomina.Domain.ReadModels;
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

        public async Task<(IEnumerable<NominaView> Nominas, int TotalRows)> ProcesarNominaAsync(NominaFiltroRequest request)
        {
            if (request.PageSize <= 0) request.PageSize = 10;
            if (request.PageNumber <= 0) request.PageNumber = 1;

            var (nominas, totalRows) = await _repository.ConsultarNominasAsync(
                request.PeriodoAnio,
                request.PeriodoMes,
                request.NominaEstado,
                request.EmpleadoNombre,
                request.EmpleadoApellido,
                request.DepartamentoCodigo,
                request.PageNumber,
                request.PageSize
            );

            return (nominas, totalRows);
        }

        public async Task<IEnumerable<int>> ObtenerAniosAsync()
        {
            var periodos = await _repository.ObtenerPeriodosAsync();
            var aniosDistintos = periodos
                .Select(p => p.PeriodoAnio)
                .Distinct()
                .OrderByDescending(a => a)
                .ToList();

            return aniosDistintos;
        }

        public async Task<IEnumerable<int>> ObtenerMesesAsync()
        {
            var periodos = await _repository.ObtenerPeriodosAsync();
            var mesesDistintos = periodos
                .Select(p => p.PeriodoMes)
                .Distinct()
                .OrderByDescending(m => m)
                .ToList();

            return mesesDistintos;
        }

        public async Task<IEnumerable<Departamentos>> ObtenerDepartamentosAsync()
        {
            var departamentos = await _repository.ObtenerDepartamentosAsync();

            return departamentos;
        }
    }
}
