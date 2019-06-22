using ERP.Gerencial.Domain.GruposEmpresariais;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infra.Data.Mappings.Gerencial
{
    public class CnaeMapping : IEntityTypeConfiguration<Cnae>
    {
        public void Configure(EntityTypeBuilder<Cnae> builder)
        {
            builder.ToTable("cnaes");

            builder.HasKey(cnae => cnae.Id);            
            builder.Property(cnae => cnae.Id)
                .HasColumnName("id");

            builder.HasAlternateKey(cnae => cnae.Codigo);
            builder.Property(cnae => cnae.Codigo)
                .HasColumnName("codigo")
                .IsRequired()
                .HasMaxLength(7);
            
            builder.Property(cnae => cnae.Descricao)
                .HasColumnName("descricao")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(cnae => cnae.CnaePai)
                .HasColumnName("cnae_pai");
            
            builder.Property(cnae => cnae.Desativado)
                .HasColumnName("desativado")
                .IsRequired()
                .HasDefaultValue(false);
            
            builder.Property(cnae => cnae.DataCadastro)
                .HasColumnName("data_cadastro")
                .IsRequired();
            
            builder.Property(cnae => cnae.DataUltimaAtualizacao)
                .HasColumnName("data_ultima_atualizacao");

            builder.Ignore(cnae => cnae.ValidationResult);
            builder.Ignore(cnae => cnae.CascadeMode);
        }
    }
}