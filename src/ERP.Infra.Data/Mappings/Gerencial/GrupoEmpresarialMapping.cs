using ERP.Gerencial.Domain.GruposEmpresariais;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infra.Data.Mappings.Gerencial
{
    public class GrupoEmpresarialMapping : IEntityTypeConfiguration<GrupoEmpresarial>
    {
        public void Configure(EntityTypeBuilder<GrupoEmpresarial> builder)
        {
            builder.ToTable("grupos_empresariais");

            builder.HasKey(grupoempresarial => grupoempresarial.Id)
                .HasName("pk_grupo_empresarial_id");
            
            builder.Property(grupoempresarial => grupoempresarial.Id)
                .HasColumnName("id");

            builder.HasIndex(grupoempresarial => grupoempresarial.Codigo)
                .IsUnique()
                .HasName("uk_grupo_empresarial_codigo");

            builder.Property(grupoempresarial => grupoempresarial.Codigo)
                .HasColumnName("codigo")
                .IsRequired()
                .HasMaxLength(30);
            
            builder.Property(grupoempresarial => grupoempresarial.Descricao)
                .HasColumnName("descricao")
                .IsRequired()
                .HasMaxLength(150);
            
            builder.Property(grupoempresarial => grupoempresarial.Desativado)
                .HasColumnName("desativado")
                .IsRequired()
                .HasDefaultValue(false);
            
            builder.Property(grupoempresarial => grupoempresarial.DataCadastro)
                .HasColumnName("data_cadastro")
                .IsRequired();
            
            builder.Property(grupoempresarial => grupoempresarial.DataUltimaAtualizacao)
                .HasColumnName("data_ultima_atualizacao");

            builder.Property(grupoempresarial => grupoempresarial.UsuarioId)
                .HasColumnName("usuario_id");

            builder.HasOne(grupoempresarial => grupoempresarial.Usuario)
                .WithMany(usuario => usuario.GruposEmpresariais)
                .HasForeignKey(grupoempresarial => grupoempresarial.UsuarioId)
                .HasConstraintName("fk_usuario_id_grupo_empresarial")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(grupoempresarial => grupoempresarial.ValidationResult);
            builder.Ignore(grupoempresarial => grupoempresarial.CascadeMode);
        }
    }
}