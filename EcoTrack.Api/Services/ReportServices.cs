using EcoTrack.Api.Data;
using EcoTrack.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoTrack.Api.Services
{
    public class ReportService
    {
        private readonly EcoTrackContext _ctx;
        public ReportService(EcoTrackContext ctx) => _ctx = ctx;

        public async Task<RelatorioCompliance> GeraRelatorioCompliance(string periodo)
        {
            // calcula por mês (formato YYYYMM)
            var totalEmissao = await _ctx.Emissoes
                .Where(e => e.DataRegistro.Year.ToString() + e.DataRegistro.Month.ToString("D2") == periodo)
                .SumAsync(e => (decimal?)e.QtdCo2) ?? 0m;

            var totalComp = await _ctx.Compensacoes
                .Where(c => c.Data.Year.ToString() + c.Data.Month.ToString("D2") == periodo)
                .SumAsync(c => (decimal?)c.QtdCo2Compensado) ?? 0m;

            var rel = new RelatorioCompliance
            {
                Periodo = periodo,
                TotalEmissao = totalEmissao,
                TotalCompensado = totalComp,
                Status = totalComp >= totalEmissao ? "CONFORME" : "NÃO CONFORME",
                DataGeracao = DateTime.UtcNow
            };

            _ctx.Relatorios.Add(rel);
            await _ctx.SaveChangesAsync();
            return rel;
        }
    }
}
