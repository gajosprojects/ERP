using AutoMapper;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands;
using ERP.Services.API.ViewModels;

namespace ERP.Services.API.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<GrupoEmpresarialViewModel, SaveGrupoEmpresarialCommand>()
                .ConstructUsing(ge => new SaveGrupoEmpresarialCommand(ge.Codigo, ge.Descricao));
            
            CreateMap<GrupoEmpresarialViewModel, UpdateGrupoEmpresarialCommand>()
                .ConstructUsing(ge => new UpdateGrupoEmpresarialCommand(ge.Id, ge.Codigo, ge.Descricao));
            
            CreateMap<GrupoEmpresarialViewModel, DeleteGrupoEmpresarialCommand>()
                .ConstructUsing(ge => new DeleteGrupoEmpresarialCommand(ge.Id));
        }
    }
}