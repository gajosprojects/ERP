using ERP.Domain.Core.Contracts;
using System;
using System.Collections.Generic;

namespace ERP.Gerencial.Domain.GruposEmpresariais.Repositories
{
    public interface IGruposEmpresariaisRepository : IRepository<GrupoEmpresarial>
    {
        void Save(Cnae cnae);
        void Save(Empresa empresa);
        void Save(Estabelecimento estabelecimento);

        void Update(Cnae cnae);
        void Update(Empresa empresa);
        void Update(Estabelecimento estabelecimento);

        IEnumerable<Cnae> GetAllCnaes();
        IEnumerable<Empresa> GetAllEmpresas();
        IEnumerable<Estabelecimento> GetAllEstabelecimentos();

        Cnae GetByCnaeId(Guid id);
        Empresa GetByEmpresaId(Guid id);
        Estabelecimento GetByEstabelecimentoId(Guid id);

        int ObterQuantidadeDeEstabelecimentosVinculadosAoCnae(Guid id);
        int ObterQuantidadeDeEstabelecimentosVinculadosAEmpresa(Guid id);
        int ObterQuantidadeDeEmpresasVinculadasAoGrupoEmpresarial(Guid id);
    }
}