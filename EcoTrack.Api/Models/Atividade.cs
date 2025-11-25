namespace EcoTrack.Api.Models
{
    public class Atividade
    {
        public int IdAtividade { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public decimal EmissaoCo2 { get; set; }
        public string OrigemDado { get; set; }

        public ICollection<Emissao> Emissoes { get; set; }
        public ICollection<Compensacao> Compensacoes { get; set; }
    }
}
