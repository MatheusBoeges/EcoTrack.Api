using EcoTrack.Api.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EcoTrack.Api.Data.Context
{
    public class EcoTrackContext : DbContext
    {
        public EcoTrackContext(DbContextOptions<EcoTrackContext> opts) : base(opts) { }

        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Emissao> Emissoes { get; set; }
        public DbSet<Compensacao> Compensacoes { get; set; }
        public DbSet<RelatorioCompliance> Relatorios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atividade>().ToTable("ATIVIDADE").HasKey(a => a.IdAtividade);
            modelBuilder.Entity<Atividade>().Property(a => a.IdAtividade).HasColumnName("ID_ATIVIDADE");
            modelBuilder.Entity<Atividade>().Property(a => a.Descricao).HasColumnName("DESCRICAO").IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Atividade>().Property(a => a.Tipo).HasColumnName("TIPO").HasMaxLength(30);
            modelBuilder.Entity<Atividade>().Property(a => a.EmissaoCo2).HasColumnName("EMISSAO_CO2");
            modelBuilder.Entity<Atividade>().Property(a => a.OrigemDado).HasColumnName("ORIGEM_DADO");

            modelBuilder.Entity<Emissao>().ToTable("EMISSAO").HasKey(e => e.IdEmissao);
            modelBuilder.Entity<Emissao>().Property(e => e.IdEmissao).HasColumnName("ID_EMISSAO");
            modelBuilder.Entity<Emissao>().Property(e => e.AtividadeId).HasColumnName("ATIVIDADE_ID");
            modelBuilder.Entity<Emissao>().Property(e => e.DataRegistro).HasColumnName("DATA_REGISTRO");
            modelBuilder.Entity<Emissao>().Property(e => e.QtdCo2).HasColumnName("QTD_CO2");
            modelBuilder.Entity<Emissao>().Property(e => e.MetodoCalculo).HasColumnName("METODO_CALCULO");
            modelBuilder.Entity<Emissao>().Property(e => e.DetalhesJson).HasColumnName("DETALHES_JSON");

            modelBuilder.Entity<Compensacao>().ToTable("COMPENSACAO").HasKey(c => c.IdCompensacao);
            modelBuilder.Entity<Compensacao>().Property(c => c.IdCompensacao).HasColumnName("ID_COMPENSACAO");
            modelBuilder.Entity<Compensacao>().Property(c => c.AtividadeId).HasColumnName("ATIVIDADE_ID");
            modelBuilder.Entity<Compensacao>().Property(c => c.Data).HasColumnName("DATA");
            modelBuilder.Entity<Compensacao>().Property(c => c.QtdCo2Compensado).HasColumnName("QTD_CO2_COMPENSADO");
            modelBuilder.Entity<Compensacao>().Property(c => c.Tipo).HasColumnName("TIPO");
            modelBuilder.Entity<Compensacao>().Property(c => c.Referencia).HasColumnName("REFERENCIA");

            modelBuilder.Entity<RelatorioCompliance>().ToTable("RELATORIO_COMPLIANCE").HasKey(r => r.IdRelatorio);
            modelBuilder.Entity<RelatorioCompliance>().Property(r => r.IdRelatorio).HasColumnName("ID_RELATORIO");
            modelBuilder.Entity<RelatorioCompliance>().Property(r => r.Periodo).HasColumnName("PERIODO");
            modelBuilder.Entity<RelatorioCompliance>().Property(r => r.TotalEmissao).HasColumnName("TOTAL_EMISSAO");
            modelBuilder.Entity<RelatorioCompliance>().Property(r => r.TotalCompensado).HasColumnName("TOTAL_COMPENSADO");
            modelBuilder.Entity<RelatorioCompliance>().Property(r => r.Status).HasColumnName("STATUS");
            modelBuilder.Entity<RelatorioCompliance>().Property(r => r.DataGeracao).HasColumnName("DATA_GERACAO");
        }
    }
}
