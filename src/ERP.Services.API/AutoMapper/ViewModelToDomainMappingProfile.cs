using AutoMapper;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.Cnaes;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.Empresas;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.Estabelecimentos;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.GruposEmpresariais;
using ERP.Gerencial.Domain.Usuarios.Commands;
using ERP.Services.API.ViewModels.Gerencial.Cnae;
using ERP.Services.API.ViewModels.Gerencial.Empresa;
using ERP.Services.API.ViewModels.Gerencial.Estabelecimento;
using ERP.Services.API.ViewModels.Gerencial.GrupoEmpresarial;
using ERP.Services.API.ViewModels.Gerencial.Usuario;

namespace ERP.Services.API.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<SaveGrupoEmpresarialViewModel, SaveGrupoEmpresarialCommand>()
                .ConstructUsing(ge => new SaveGrupoEmpresarialCommand(ge.Codigo, ge.Descricao, ge.UsuarioId));
            
            CreateMap<UpdateGrupoEmpresarialViewModel, UpdateGrupoEmpresarialCommand>()
                .ConstructUsing(ge => new UpdateGrupoEmpresarialCommand(ge.Id, ge.Codigo, ge.Descricao, ge.UsuarioId));
            
            CreateMap<DeleteGrupoEmpresarialViewModel, DeleteGrupoEmpresarialCommand>()
                .ConstructUsing(ge => new DeleteGrupoEmpresarialCommand(ge.Id, ge.UsuarioId));

            CreateMap<SaveCnaeViewModel, SaveCnaeCommand>()
                .ConstructUsing(c => new SaveCnaeCommand(c.Codigo, c.Descricao, c.CnaePai, c.UsuarioId));

            CreateMap<UpdateCnaeViewModel, UpdateCnaeCommand>()
                .ConstructUsing(c => new UpdateCnaeCommand(c.Id, c.Codigo, c.Descricao, c.CnaePai, c.UsuarioId));

            CreateMap<DeleteCnaeViewModel, DeleteCnaeCommand>()
                .ConstructUsing(c => new DeleteCnaeCommand(c.Id, c.UsuarioId));

            CreateMap<SaveEmpresaViewModel, SaveEmpresaCommand>()
                .ConstructUsing(e => new SaveEmpresaCommand(e.UsuarioId, e.Codigo, e.Descricao, e.NomeFantasia, e.Email, e.Site, e.DataRegistro, e.Logotipo, e.Observacao, e.Documento, e.TipoIdentificacao, e.GrupoEmpresarialId));

            CreateMap<UpdateEmpresaViewModel, UpdateEmpresaCommand>()
                .ConstructUsing(e => new UpdateEmpresaCommand(e.Id, e.UsuarioId, e.Codigo, e.Descricao, e.NomeFantasia, e.Email, e.Site, e.DataRegistro, e.Logotipo, e.Observacao, e.Documento, e.TipoIdentificacao, e.GrupoEmpresarialId));

            CreateMap<DeleteEmpresaViewModel, DeleteEmpresaCommand>()
                .ConstructUsing(e => new DeleteEmpresaCommand(e.Id, e.UsuarioId));

            CreateMap<SaveEstabelecimentoViewModel, SaveEstabelecimentoCommand>()
                .ConstructUsing(e => new SaveEstabelecimentoCommand(e.UsuarioId, e.Codigo, e.Descricao, e.NomeFantasia, e.InscricaoEstadual, e.InscricaoMunicipal, e.Email, e.Site, e.DataRegistro, e.Logotipo, e.Matriz, e.Observacao, e.Documento, e.TipoIdentificacao, e.EmpresaId, e.CnaeId));

            CreateMap<UpdateEstabelecimentoViewModel, UpdateEstabelecimentoCommand>()
                .ConstructUsing(e => new UpdateEstabelecimentoCommand(e.Id, e.UsuarioId, e.Codigo, e.Descricao, e.NomeFantasia, e.InscricaoEstadual, e.InscricaoMunicipal, e.Email, e.Site, e.DataRegistro, e.Logotipo, e.Matriz, e.Observacao, e.Documento, e.TipoIdentificacao, e.EmpresaId, e.CnaeId));

            CreateMap<DeleteEstabelecimentoViewModel, DeleteEstabelecimentoCommand>()
                .ConstructUsing(e => new DeleteEstabelecimentoCommand(e.Id, e.UsuarioId));

            CreateMap<UsuarioViewModel, SaveUsuarioCommand>()
                .ConstructUsing(u => new SaveUsuarioCommand(u.Id, u.Nome, u.Sobrenome, u.Email));
        }
    }
}