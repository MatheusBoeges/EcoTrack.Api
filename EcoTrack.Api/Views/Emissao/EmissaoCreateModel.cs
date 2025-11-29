namespace EcoTrack.Api.Views.Emissao
{
    public class EmissaoCreateModel
    {
        public int AtividadeId { get; set; }
        public decimal QtdCo2 { get; set; }
        public string? MetodoCalculo { get; set; }
        public string? DetalhesJson { get; set; }
    }
}
