using AutoMapper;
using ERP.Gerencial.Domain.GruposEmpresariais;
using ERP.Gerencial.Domain.Usuarios;
using ERP.Services.API.ViewModels.Gerencial.Cnae;
using ERP.Services.API.ViewModels.Gerencial.Empresa;
using ERP.Services.API.ViewModels.Gerencial.Estabelecimento;
using ERP.Services.API.ViewModels.Gerencial.GrupoEmpresarial;
using ERP.Services.API.ViewModels.Gerencial.Usuario;

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