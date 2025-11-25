namespace EcoTrack.Api.Models
{
    public class RelatorioCompliance
    {
        public int IdRelatorio { get; set; }
        public string Periodo { get; set; } // ex "202509"
        public decimal TotalEmissao { get; set; }
        public decimal TotalCompensado { get; set; }
        public string Status { get; set; }
        public DateTime DataGeracao { get; set; }
    }
}
