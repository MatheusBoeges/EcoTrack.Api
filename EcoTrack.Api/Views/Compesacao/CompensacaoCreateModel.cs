namespace EcoTrack.Api.Views.Compesacao
{
    public class CompensacaoCreateModel
    {
        public int AtividadeId { get; set; }
        public decimal QtdCo2Compensado { get; set; }
        public string? Tipo { get; set; }
        public string? Referencia { get; set; }
    }
}
