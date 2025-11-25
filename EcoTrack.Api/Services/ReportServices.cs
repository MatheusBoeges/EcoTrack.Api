using EcoTrack.Api.Data.Context;
using EcoTrack.Api.Models;

namespace EcoTrack.Api.Services
{
    public class ReportServices
    {
        private readonly EcoTrackContext _ctx;
        public ReportService(EcoTrackContext ctx) => _ctx = ctx;

        public async Task<RelatorioCompliance> GeraRelatorioCompliance(string periodo)
        {
            // opção 1: chamar procedure PL/SQL no Oracle (exemplo)
            // opção 2: executar via LINQ (aqui implementação EF)
            var totalEmissao = await _ctx.Emissoes
                .Where(e => e.DataRegistro.ToString("yyyyMM") == periodo)
                .SumAsync(e => (decimal?)e.QtdCo2) ?? 0m;
            var totalComp = await _ctx.Compensacoes
                .Where(c => c.Data.ToString("yyyyMM") == periodo)
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
