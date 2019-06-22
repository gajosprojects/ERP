using AutoMapper;
using ERP.Gerencial.Domain.GruposEmpresariais;
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