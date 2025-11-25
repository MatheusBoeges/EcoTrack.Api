using EcoTrack.Api.Data.Context;
using EcoTrack.Api.Models;
using EcoTrack.Api.Views.Emissao;
using Microsoft.AspNetCore.Mvc;

namespace EcoTrack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmissoesController : ControllerBase
    {
        private readonly EcoTrackContext _ctx;
        public EmissoesController(EcoTrackContext ctx) => _ctx = ctx;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmissaoCreateModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var emissao = new Emissao
            {
                AtividadeId = model.AtividadeId,
                QtdCo2 = model.QtdCo2,
                MetodoCalculo = model.MetodoCalculo,
                DetalhesJson = model.DetalhesJson
            };
            await _ctx.Emissoes.AddAsync(emissao);

            // atualiza total de atividade (simula o trigger do banco)
            var atividade = await _ctx.Atividades.FindAsync(model.AtividadeId);
            if (atividade == null) return NotFound($"Atividade {model.AtividadeId} não encontrada.");
            atividade.EmissaoCo2 += model.QtdCo2;

            await _ctx.SaveChangesAsync();

            return Ok(emissao);
        }
    }
}
