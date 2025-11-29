using System.ComponentModel.DataAnnotations;

namespace EcoTrack.Api.Models
{
    public class RelatorioCompliance
    {
        [Key]
        public int IdRelatorio { get; set; }
        public string Periodo { get; set; } = string.Empty;
        public decimal TotalEmissao { get; set; }
        public decimal TotalCompensado { get; set; }
        public string? Status { get; set; }
        public DateTime DataGeracao { get; set; } = DateTime.UtcNow;
    }
}
