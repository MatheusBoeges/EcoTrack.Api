using EcoTrack.Api.Data.Context;
using EcoTrack.Api.Models;
using EcoTrack.Api.Views.Compesacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoTrack.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CompensacoesController : ControllerBase
    {
        private readonly EcoTrackContext _ctx;
        public CompensacoesController(EcoTrackContext ctx) => _ctx = ctx;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompensacaoCreateModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var comp = new Compensacao
            {
                AtividadeId = model.AtividadeId,
                QtdCo2Compensado = model.QtdCo2Compensado,
                Tipo = model.Tipo,
                Referencia = model.Referencia
            };
            await _ctx.Compensacoes.AddAsync(comp);

            var atividade = await _ctx.Atividades.FindAsync(model.AtividadeId);
            if (atividade == null) return NotFound($"Atividade {model.AtividadeId} não encontrada.");
            atividade.EmissaoCo2 -= model.QtdCo2Compensado;

            await _ctx.SaveChangesAsync();

            return Ok(comp);
        }
    }
}
