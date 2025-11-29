using System.ComponentModel.DataAnnotations;

namespace EcoTrack.Api.Models
{
    public class Emissao
    {
        [Key]
        public int IdEmissao { get; set; }
        public int AtividadeId { get; set; }
        public DateTime DataRegistro { get; set; } = DateTime.UtcNow;
        public decimal QtdCo2 { get; set; }
        public string? MetodoCalculo { get; set; }
        public string? DetalhesJson { get; set; }

        public Atividade? Atividade { get; set; }
    }
}
