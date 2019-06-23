using ERP.Gerencial.Domain.GruposEmpresariais;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infra.Data.Mappings.Gerencial
{
    public class EstabelecimentoMapping : IEntityTypeConfiguration<Estabelecimento>
    {
        public void Configure(EntityTypeBuilder<Estabelecimento> builder)
        {
            builder.ToTable("estabelecimentos");

            builder.HasKey(estabelecimento => estabelecimento.Id);            
            builder.Property(estabelecimento => estabelecimento.Id)
                .HasColumnName("id");

            builder.HasAlternateKey(estabelecimento => estabelecimento.Codigo);
            builder.Property(estabelecimento => estabelecimento.Codigo)
                .HasColumnName("codigo")
                .IsRequired()
                .HasMaxLength(30);
            
            builder.Property(estabelecimento => estabelecimento.Descricao)
                .HasColumnName("descricao")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(estabelecimento => estabelecimento.NomeFantasia)
                .HasColumnName("nome_fantasia")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(estabelecimento => estabelecimento.InscricaoEstadual)
                .HasColumnName("inscricao_estadual")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(estabelecimento => estabelecimento.InscricaoMunicipal)
                .HasColumnName("inscricao_municipal")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(estabelecimento => estabelecimento.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(estabelecimento => estabelecimento.Site)
                .HasColumnName("site")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(estabelecimento => estabelecimento.Bloqueado)
                .HasColumnName("bloqueado")
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(estabelecimento => estabelecimento.DataRegistro)
                .HasColumnName("data_registro")
                .IsRequired();

            builder.Property(estabelecimento => estabelecimento.Logotipo)
                .HasColumnName("logotipo");

            builder.Property(estabelecimento => estabelecimento.Matriz)
                .HasColumnName("matriz");
            
            builder.Property(estabelecimento => estabelecimento.Desativado)
                .HasColumnName("desativado")
                .IsRequired()
                .HasDefaultValue(false);
            
            builder.Property(estabelecimento => estabelecimento.DataCadastro)
                .HasColumnName("data_cadastro")
                .IsRequired();
            
            builder.Property(estabelecimento => estabelecimento.DataUltimaAtualizacao)
                .HasColumnName("data_ultima_atualizacao");

            builder.Property(estabelecimento => estabelecimento.Observacao)
                .HasColumnName("observacao");

            builder.Property(estabelecimento => estabelecimento.Documento)
                .HasColumnName("documento")
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(estabelecimento => estabelecimento.TipoIdentificacao)
                .HasColumnName("tipo_identificacao")
                .IsRequired();

            builder.HasOne(estabelecimento => estabelecimento.Empresa)
                .WithMany(empresa => empresa.Estabelecimentos)
                .HasForeignKey(estabelecimento => estabelecimento.EmpresaId)
                .HasConstraintName("empresa_id");

            builder.HasOne(estabelecimento => estabelecimento.Cnae)
                .WithMany(cnae => cnae.Estabelecimentos)
                .HasForeignKey(estabelecimento => estabelecimento.CnaeId)
                .HasConstraintName("cnae_id");

            builder.Ignore(estabelecimento => estabelecimento.ValidationResult);
            builder.Ignore(estabelecimento => estabelecimento.CascadeMode);
        }
    }
}