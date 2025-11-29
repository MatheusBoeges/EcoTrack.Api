using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _cfg;
    public AuthController(IConfiguration cfg) => _cfg = cfg;

    [HttpPost("token")]
    public IActionResult Token([FromBody] AuthRequest req)
    {
        // USO SIMPLIFICADO SOMENTE PARA TESTES (não usar em produção)
        if (req.Username != "admin" || req.Password != "password") return Unauthorized();

        var key = Encoding.ASCII.GetBytes(_cfg["Jwt:Key"] ?? "ChangeThisSecretInProduction!");
        var tokenHandler = new JwtSecurityTokenHandler();
        var claims = new[] { new Claim(ClaimTypes.Name, req.Username), new Claim(ClaimTypes.Role, "Admin") };
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(4),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Ok(new { token = tokenHandler.WriteToken(token) });
    }
}

public class AuthRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
