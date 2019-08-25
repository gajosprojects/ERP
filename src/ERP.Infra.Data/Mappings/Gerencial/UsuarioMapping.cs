using ERP.Gerencial.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infra.Data.Mappings.Gerencial
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");

            builder.HasKey(usuario => usuario.Id)
                .HasName("pk_usuario_id");

            builder.Property(usuario => usuario.Id)
                .HasColumnName("id");

            builder.Property(usuario => usuario.Nome)
                .HasColumnName("nome")
                .IsRequired();

            builder.Property(usuario => usuario.Sobrenome)
                .HasColumnName("sobrenome")
                .IsRequired();

            builder.Property(usuario => usuario.Email)
                .HasColumnName("email")
                .IsRequired();

            builder.Property(usuario => usuario.Excluido)
                .HasColumnName("excluido")
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(usuario => usuario.DataCadastro)
                .HasColumnName("data_cadastro")
                .IsRequired();

            builder.Property(usuario => usuario.DataUltimaAtualizacao)
                .HasColumnName("data_ultima_atualizacao");

            builder.Ignore(usuario => usuario.UsuarioId);
            builder.Ignore(usuario => usuario.ValidationResult);
            builder.Ignore(usuario => usuario.CascadeMode);
        }
    }
}
