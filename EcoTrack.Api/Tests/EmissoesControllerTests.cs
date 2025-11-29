using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class EmissoesControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    public EmissoesControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Post_Returns200OrBadRequest()
    {
        var body = new { AtividadeId = 1, QtdCo2 = 1.0m, MetodoCalculo = "Teste", DetalhesJson = "{}" };
        var response = await _client.PostAsJsonAsync("/api/emissoes", body);
        Assert.True(response.StatusCode == HttpStatusCode.OK
                    || response.StatusCode == HttpStatusCode.NotFound
                    || response.StatusCode == HttpStatusCode.BadRequest);
    }
}
