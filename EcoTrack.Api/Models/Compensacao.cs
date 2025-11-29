using System.ComponentModel.DataAnnotations;

namespace EcoTrack.Api.Models
{
    public class Compensacao
    {
        [Key]
        public int IdCompensacao { get; set; }
        public int AtividadeId { get; set; }
        public DateTime Data { get; set; } = DateTime.UtcNow;
        public decimal QtdCo2Compensado { get; set; }
        public string? Tipo { get; set; }
        public string? Referencia { get; set; }

        public Atividade? Atividade { get; set; }
    }
}
