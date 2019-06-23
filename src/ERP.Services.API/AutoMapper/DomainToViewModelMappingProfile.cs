using AutoMapper;
using ERP.Gerencial.Domain.GruposEmpresariais;
using ERP.Gerencial.Domain.Usuarios;
using ERP.Services.API.ViewModels.Gerencial;

namespace ERP.Services.API.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<GrupoEmpresarial, GrupoEmpresarialViewModel>();
            CreateMap<Empresa, EmpresaViewModel>();
            CreateMap<Estabelecimento, EstabelecimentoViewModel>();
            CreateMap<Cnae, CnaeViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}