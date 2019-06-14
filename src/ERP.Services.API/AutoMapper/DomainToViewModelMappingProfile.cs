using AutoMapper;
using ERP.Admin.Domain.GruposEmpresariais;
using ERP.Services.API.ViewModels;

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
        }
    }
}