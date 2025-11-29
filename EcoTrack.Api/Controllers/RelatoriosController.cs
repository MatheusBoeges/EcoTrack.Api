using EcoTrack.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/relatorios")]
public class RelatoriosController : ControllerBase
{
    private readonly ReportService _reportService;
    public RelatoriosController(ReportService reportService) => _reportService = reportService;

    [HttpPost("gera")]
    public async Task<IActionResult> GeraRelatorio([FromQuery] string periodo)
    {
        if (string.IsNullOrWhiteSpace(periodo)) return BadRequest("periodo obrigatório no formato YYYYMM");

        var rel = await _reportService.GeraRelatorioCompliance(periodo);
        return Ok(rel);
    }
}
