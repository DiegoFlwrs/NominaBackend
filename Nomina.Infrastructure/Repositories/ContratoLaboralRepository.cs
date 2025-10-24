using Microsoft.EntityFrameworkCore;
using Nomina.Domain.Entities;
using Nomina.Domain.Interfaces;
using Nomina.Infrastructure.Persistence;

namespace Nomina.Infrastructure.Repositories
{
    public class ContratoLaboralRepository : IContratoLaboralRepository
    {
        private readonly AppDbContext _context;

        public ContratoLaboralRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContratoLaboral>> ConsultarContratos()
        {
            return await _context.ContratosLaborales
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task InsertarContrato(ContratoLaboral contrato)
        {
            if (string.IsNullOrWhiteSpace(contrato.ContratoCodigo))
            {
                contrato.ContratoCodigo = "C" + new Random().Next(100, 999).ToString();
            }

            await _context.ContratosLaborales.AddAsync(contrato);
            await _context.SaveChangesAsync();
        }

        public async Task ModificarContrato(ContratoLaboral contrato)
        {
            _context.ContratosLaborales.Update(contrato);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarContrato(string contratoCodigo)
        {
            var contrato = await _context.ContratosLaborales
                .FirstOrDefaultAsync(c => c.ContratoCodigo == contratoCodigo);

            if (contrato != null)
            {
                _context.ContratosLaborales.Remove(contrato);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExisteContratoVigente(string empleadoCodigo)
        {
            return await _context.ContratosLaborales
                .AnyAsync(c => c.EmpleadoCodigo == empleadoCodigo && c.ContratoEstado == "A");
        }

        public async Task<bool> ExisteEmpleadoActivo(string empleadoCodigo)
        {
            return await _context.Empleados
                .AnyAsync(e => e.EmpleadoCodigo == empleadoCodigo && e.EmpleadoEstado == "A");
        }

        public async Task<ContratoLaboral?> ObtenerContrato(string contratoCodigo)
        {
            return await _context.ContratosLaborales
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ContratoCodigo == contratoCodigo);
        }

        public async Task RegistrarHistorial(string contratoCodigo, string evento, string motivo)
        {
            var historial = new HistorialContrato
            {
                HistorialCodigo = "H" + new Random().Next(100000, 999999).ToString(),
                ContratoCodigo = contratoCodigo,
                EventoCodigo = evento,
                HistorialMotivo = motivo
            };

            await _context.HistorialContratos.AddAsync(historial);
            await _context.SaveChangesAsync();
        }
    }
}
