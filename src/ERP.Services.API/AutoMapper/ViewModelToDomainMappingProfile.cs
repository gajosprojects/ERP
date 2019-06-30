using AutoMapper;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands;
using ERP.Gerencial.Domain.Usuarios.Commands;
using ERP.Services.API.ViewModels.Gerencial.GrupoEmpresarial;
using ERP.Services.API.ViewModels.Gerencial.Usuario;

namespace ERP.Services.API.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<SaveGrupoEmpresarialViewModel, SaveGrupoEmpresarialCommand>()
                .ConstructUsing(ge => new SaveGrupoEmpresarialCommand(ge.Codigo, ge.Descricao));
            
            CreateMap<UpdateGrupoEmpresarialViewModel, UpdateGrupoEmpresarialCommand>()
                .ConstructUsing(ge => new UpdateGrupoEmpresarialCommand(ge.Id, ge.Codigo, ge.Descricao));
            
            CreateMap<DeleteGrupoEmpresarialViewModel, DeleteGrupoEmpresarialCommand>()
                .ConstructUsing(ge => new DeleteGrupoEmpresarialCommand(ge.Id));

            CreateMap<UsuarioViewModel, SaveUsuarioCommand>()
                .ConstructUsing(u => new SaveUsuarioCommand(u.Id, u.Nome, u.Sobrenome, u.Email));
        }
    }
}