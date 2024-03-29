﻿using ERP.Gerencial.Domain.GruposEmpresariais.Types;
using ERP.Services.API.ViewModels.Gerencial.GrupoEmpresarial;
using ERP.Services.API.ViewModels.Gerencial.Usuario;
using System;

namespace ERP.Services.API.ViewModels.Gerencial.Empresa
{
    public class EmpresaViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public bool Excluido { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public DateTime DataRegistro { get; set; }
        public byte[] Logotipo { get; set; }
        public string Observacao { get; set; }
        public string Documento { get; set; }
        public TipoIdentificacao TipoIdentificacao { get; set; }
        public GrupoEmpresarialViewModel GrupoEmpresarial { get; set; }
        public UsuarioViewModel Usuario { get; set; }

        public EmpresaViewModel()
        {
            GrupoEmpresarial = new GrupoEmpresarialViewModel();
            Usuario = new UsuarioViewModel();
        }
    }
}
