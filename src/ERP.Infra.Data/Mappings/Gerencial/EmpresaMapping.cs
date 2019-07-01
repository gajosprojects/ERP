using ERP.Gerencial.Domain.GruposEmpresariais;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infra.Data.Mappings.Gerencial
{
    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("empresas");

            builder.HasKey(empresa => empresa.Id)
                .HasName("pk_empresa_id");

            builder.Property(empresa => empresa.Id)
                .HasColumnName("id");

            builder.HasAlternateKey(empresa => empresa.Codigo);
            builder.Property(empresa => empresa.Codigo)
                .HasColumnName("codigo")
                .IsRequired()
                .HasMaxLength(30);
            
            builder.Property(empresa => empresa.Descricao)
                .HasColumnName("descricao")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(empresa => empresa.NomeFantasia)
                .HasColumnName("nome_fantasia")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(empresa => empresa.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(empresa => empresa.Site)
                .HasColumnName("site")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(empresa => empresa.Bloqueada)
                .HasColumnName("bloqueada")
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(empresa => empresa.DataRegistro)
                .HasColumnName("data_registro")
                .IsRequired();

            builder.Property(empresa => empresa.Logotipo)
                .HasColumnName("logotipo");

            builder.Property(empresa => empresa.Observacao)
                .HasColumnName("observacao");
            
            builder.Property(empresa => empresa.Desativado)
                .HasColumnName("desativado")
                .IsRequired()
                .HasDefaultValue(false);
            
            builder.Property(empresa => empresa.DataCadastro)
                .HasColumnName("data_cadastro")
                .IsRequired();
            
            builder.Property(empresa => empresa.DataUltimaAtualizacao)
                .HasColumnName("data_ultima_atualizacao");

            builder.Property(empresa => empresa.Documento)
                .HasColumnName("documento")
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(empresa => empresa.TipoIdentificacao)
                .HasColumnName("tipo_identificacao")
                .IsRequired();

            builder.Property(empresa => empresa.GrupoEmpresarialId)
                .HasColumnName("grupo_empresarial_id");

            builder.HasOne(empresa => empresa.GrupoEmpresarial)
                .WithMany(grupoEmpresarial => grupoEmpresarial.Empresas)
                .HasForeignKey(empresa => empresa.GrupoEmpresarialId)
                .HasConstraintName("fk_grupo_empresarial_id_empresa");

            builder.Property(empresa => empresa.UsuarioId)
                .HasColumnName("usuario_id");

            builder.HasOne(empresa => empresa.Usuario)
                .WithMany(usuario => usuario.Empresas)
                .HasForeignKey(empresa => empresa.UsuarioId)
                .HasConstraintName("fk_usuario_id_empresa")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(empresa => empresa.ValidationResult);
            builder.Ignore(empresa => empresa.CascadeMode);
        }
    }
}