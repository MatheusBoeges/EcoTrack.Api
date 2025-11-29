using System.ComponentModel.DataAnnotations;

namespace EcoTrack.Api.Models
{
    public class Atividade
    {
        [Key]
        public int IdAtividade { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string? Tipo { get; set; }
        public decimal EmissaoCo2 { get; set; } = 0m;
        public string? OrigemDado { get; set; }

        public ICollection<Emissao> Emissoes { get; set; } = new List<Emissao>();
        public ICollection<Compensacao> Compensacoes { get; set; } = new List<Compensacao>();
    }
}
