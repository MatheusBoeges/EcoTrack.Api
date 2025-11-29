using EcoTrack.Api.Data;
using EcoTrack.Api.Views.Emissao;
using Microsoft.AspNetCore.Mvc;

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

        var atividade = await _ctx.Atividades.FindAsync(model.AtividadeId);
        if (atividade == null) return NotFound($"Atividade {model.AtividadeId} não encontrada.");

        var emissao = new EcoTrack.Api.Models.Emissao
        {
            AtividadeId = model.AtividadeId,
            QtdCo2 = model.QtdCo2,
            MetodoCalculo = model.MetodoCalculo,
            DetalhesJson = model.DetalhesJson
        };

        await _ctx.Emissoes.AddAsync(emissao);
        atividade.EmissaoCo2 += model.QtdCo2;

        await _ctx.SaveChangesAsync();

        return Ok(emissao);
    }
}
