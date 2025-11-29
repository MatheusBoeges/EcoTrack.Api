using EcoTrack.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class AtividadesController : ControllerBase
{
    private readonly EcoTrackContext _ctx;
    public AtividadesController(EcoTrackContext ctx) => _ctx = ctx;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        if (page <= 0) page = 1;
        if (pageSize <= 0 || pageSize > 100) pageSize = 10;

        var query = _ctx.Atividades.AsNoTracking();
        var total = await query.CountAsync();
        var items = await query
            .OrderBy(a => a.IdAtividade)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var result = new
        {
            Page = page,
            PageSize = pageSize,
            Total = total,
            Items = items
        };
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var atividade = await _ctx.Atividades
            .Include(a => a.Emissoes)
            .Include(a => a.Compensacoes)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.IdAtividade == id);
        if (atividade == null) return NotFound();
        return Ok(atividade);
    }
}
