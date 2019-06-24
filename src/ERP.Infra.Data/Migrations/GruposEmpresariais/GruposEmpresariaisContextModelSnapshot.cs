﻿// <auto-generated />
using System;
using ERP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ERP.Infra.Data.Migrations.GruposEmpresariais
{
    [DbContext(typeof(GruposEmpresariaisContext))]
    partial class GruposEmpresariaisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ERP.Gerencial.Domain.GruposEmpresariais.Cnae", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<Guid>("CnaePai")
                        .HasColumnName("cnae_pai");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnName("codigo")
                        .HasMaxLength(7);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("data_cadastro");

                    b.Property<DateTime>("DataUltimaAtualizacao")
                        .HasColumnName("data_ultima_atualizacao");

                    b.Property<bool>("Desativado")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("desativado")
                        .HasDefaultValue(false);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("descricao")
                        .HasMaxLength(255);

                    b.HasKey("Id")
                        .HasName("pk_cnae_id");

                    b.HasAlternateKey("Codigo");

                    b.ToTable("cnaes");
                });

            modelBuilder.Entity("ERP.Gerencial.Domain.GruposEmpresariais.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<bool>("Bloqueada")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("bloqueada")
                        .HasDefaultValue(false);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnName("codigo")
                        .HasMaxLength(30);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("data_cadastro");

                    b.Property<DateTime>("DataRegistro")
                        .HasColumnName("data_registro");

                    b.Property<DateTime>("DataUltimaAtualizacao")
                        .HasColumnName("data_ultima_atualizacao");

                    b.Property<bool>("Desativado")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("desativado")
                        .HasDefaultValue(false);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("descricao")
                        .HasMaxLength(150);

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnName("documento")
                        .HasMaxLength(14);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(150);

                    b.Property<Guid>("GrupoEmpresarialId")
                        .HasColumnName("grupo_empresarial_id");

                    b.Property<byte[]>("Logotipo")
                        .HasColumnName("logotipo");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnName("nome_fantasia")
                        .HasMaxLength(150);

                    b.Property<string>("Observacao")
                        .HasColumnName("observacao");

                    b.Property<string>("Site")
                        .IsRequired()
                        .HasColumnName("site")
                        .HasMaxLength(100);

                    b.Property<int>("TipoIdentificacao")
                        .HasColumnName("tipo_identificacao");

                    b.HasKey("Id")
                        .HasName("pk_empresa_id");

                    b.HasAlternateKey("Codigo");

                    b.HasIndex("GrupoEmpresarialId");

                    b.ToTable("empresas");
                });

            modelBuilder.Entity("ERP.Gerencial.Domain.GruposEmpresariais.Estabelecimento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<bool>("Bloqueado")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("bloqueado")
                        .HasDefaultValue(false);

                    b.Property<Guid>("CnaeId")
                        .HasColumnName("cnae_id");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnName("codigo")
                        .HasMaxLength(30);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("data_cadastro");

                    b.Property<DateTime>("DataRegistro")
                        .HasColumnName("data_registro");

                    b.Property<DateTime>("DataUltimaAtualizacao")
                        .HasColumnName("data_ultima_atualizacao");

                    b.Property<bool>("Desativado")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("desativado")
                        .HasDefaultValue(false);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("descricao")
                        .HasMaxLength(150);

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnName("documento")
                        .HasMaxLength(14);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(150);

                    b.Property<Guid>("EmpresaId")
                        .HasColumnName("empresa_id");

                    b.Property<string>("InscricaoEstadual")
                        .IsRequired()
                        .HasColumnName("inscricao_estadual")
                        .HasMaxLength(20);

                    b.Property<string>("InscricaoMunicipal")
                        .IsRequired()
                        .HasColumnName("inscricao_municipal")
                        .HasMaxLength(20);

                    b.Property<byte[]>("Logotipo")
                        .HasColumnName("logotipo");

                    b.Property<bool>("Matriz")
                        .HasColumnName("matriz");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnName("nome_fantasia")
                        .HasMaxLength(150);

                    b.Property<string>("Observacao")
                        .HasColumnName("observacao");

                    b.Property<string>("Site")
                        .IsRequired()
                        .HasColumnName("site")
                        .HasMaxLength(100);

                    b.Property<int>("TipoIdentificacao")
                        .HasColumnName("tipo_identificacao");

                    b.HasKey("Id")
                        .HasName("pk_estabelecimento_id");

                    b.HasAlternateKey("Codigo");

                    b.HasIndex("CnaeId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("estabelecimentos");
                });

            modelBuilder.Entity("ERP.Gerencial.Domain.GruposEmpresariais.GrupoEmpresarial", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnName("codigo")
                        .HasMaxLength(30);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("data_cadastro");

                    b.Property<DateTime>("DataUltimaAtualizacao")
                        .HasColumnName("data_ultima_atualizacao");

                    b.Property<bool>("Desativado")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("desativado")
                        .HasDefaultValue(false);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("descricao")
                        .HasMaxLength(150);

                    b.HasKey("Id")
                        .HasName("pk_grupo_empresarial_id");

                    b.HasAlternateKey("Codigo");

                    b.ToTable("grupos_empresariais");
                });

            modelBuilder.Entity("ERP.Gerencial.Domain.Usuarios.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime>("DataUltimaAtualizacao");

                    b.Property<bool>("Desativado");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnName("sobrenome");

                    b.HasKey("Id")
                        .HasName("pk_usuario_id");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("ERP.Gerencial.Domain.GruposEmpresariais.Empresa", b =>
                {
                    b.HasOne("ERP.Gerencial.Domain.GruposEmpresariais.GrupoEmpresarial", "GrupoEmpresarial")
                        .WithMany("Empresas")
                        .HasForeignKey("GrupoEmpresarialId")
                        .HasConstraintName("fk_grupo_empresarial_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ERP.Gerencial.Domain.GruposEmpresariais.Estabelecimento", b =>
                {
                    b.HasOne("ERP.Gerencial.Domain.GruposEmpresariais.Cnae", "Cnae")
                        .WithMany("Estabelecimentos")
                        .HasForeignKey("CnaeId")
                        .HasConstraintName("fk_cnae_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ERP.Gerencial.Domain.GruposEmpresariais.Empresa", "Empresa")
                        .WithMany("Estabelecimentos")
                        .HasForeignKey("EmpresaId")
                        .HasConstraintName("fk_empresa_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
