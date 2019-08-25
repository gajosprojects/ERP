using Dapper;
using ERP.Gerencial.Domain.GruposEmpresariais;
using ERP.Gerencial.Domain.GruposEmpresariais.Repositories;
using ERP.Gerencial.Domain.Usuarios;
using ERP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERP.Infra.Data.Repositories.Gerencial
{
    public class GruposEmpresariaisRepository : Repository<GrupoEmpresarial>, IGruposEmpresariaisRepository
    {
        public GruposEmpresariaisRepository(GruposEmpresariaisContext db) : base(db)
        {
        }

        public void Save(Cnae cnae) => _db.Cnaes.Add(cnae);

        public void Save(Empresa empresa) => _db.Empresas.Add(empresa);

        public void Save(Estabelecimento estabelecimento) => _db.Estabelecimentos.Add(estabelecimento);

        public void Update(Cnae cnae) => _db.Cnaes.Update(cnae);

        public void Update(Empresa empresa) => _db.Empresas.Update(empresa);

        public void Update(Estabelecimento estabelecimento) => _db.Estabelecimentos.Update(estabelecimento);

        public override IEnumerable<GrupoEmpresarial> GetAll()
        {
            return _db.Database.GetDbConnection().Query<GrupoEmpresarial, Usuario, GrupoEmpresarial>(@"
                SELECT 
                    * 
                FROM
                    GRUPOS_EMPRESARIAIS GE
                    JOIN USUARIOS U ON U.ID = GE.USUARIO_ID
                WHERE
                    GE.EXCLUIDO = 0
                ORDER BY 
                    GE.DESCRICAO",
                (grupoEmpresarial, usuario) =>
                {
                    grupoEmpresarial.AtribuirUsuario(usuario);
                    return grupoEmpresarial;
                }
            );
        }

        public override GrupoEmpresarial GetById(Guid id)
        {
            return _db.Database.GetDbConnection().Query<GrupoEmpresarial, Usuario, GrupoEmpresarial>(@"
                SELECT 
                    * 
                FROM 
                    GRUPOS_EMPRESARIAIS GE
                    JOIN USUARIOS U ON U.ID = GE.USUARIO_ID
                WHERE 
                    GE.ID = @id
                    AND GE.EXCLUIDO = 0",
                (grupoEmpresarial, usuario) =>
                {
                    grupoEmpresarial.AtribuirUsuario(usuario);
                    return grupoEmpresarial;
                }, 
                new { id }
            )
            .FirstOrDefault();
        }

        public IEnumerable<Cnae> GetAllCnaes()
        {
            return _db.Database.GetDbConnection().Query<Cnae, Usuario, Cnae>(@"
                SELECT 
                    * 
                FROM
                    CNAES C
                    JOIN USUARIOS U ON U.ID = C.USUARIO_ID
                WHERE
                    C.EXCLUIDO = 0
                ORDER BY 
                    C.DESCRICAO",
                (cnae, usuario) =>
                {
                    cnae.AtribuirUsuario(usuario);
                    return cnae;
                }
            );
        }

        public Cnae GetByCnaeId(Guid id)
        {
            return _db.Database.GetDbConnection().Query<Cnae, Usuario, Cnae>(@"
                SELECT 
                    * 
                FROM 
                    CNAES C
                    JOIN USUARIOS U ON U.ID = C.USUARIO_ID
                WHERE 
                    C.ID = @id
                    AND C.EXCLUIDO = 0",
                (cnae, usuario) =>
                {
                    cnae.AtribuirUsuario(usuario);
                    return cnae;
                },
                new { id }
            )
            .FirstOrDefault();
        }

        public IEnumerable<Empresa> GetAllEmpresas()
        {
            return _db.Database.GetDbConnection().Query<Empresa, Usuario, GrupoEmpresarial, Empresa>(@"
                SELECT 
                    * 
                FROM
                    EMPRESAS E
                    JOIN USUARIOS U ON U.ID = E.USUARIO_ID
					JOIN GRUPOS_EMPRESARIAIS GE ON GE.ID = E.GRUPO_EMPRESARIAL_ID
                WHERE
                    E.EXCLUIDO = 0
                ORDER BY 
                    E.DESCRICAO",
                (empresa, usuario, grupoEmpresarial) =>
                {
                    empresa.AtribuirUsuario(usuario);
                    empresa.AtribuirGrupoEmpresarial(grupoEmpresarial);
                    return empresa;
                }
            );
        }

        public Empresa GetByEmpresaId(Guid id)
        {
            return _db.Database.GetDbConnection().Query<Empresa, Usuario, GrupoEmpresarial, Empresa>(@"
                SELECT 
                    * 
                FROM 
                    EMPRESAS E
                    JOIN USUARIOS U ON U.ID = E.USUARIO_ID
					JOIN GRUPOS_EMPRESARIAIS GE ON GE.ID = E.GRUPO_EMPRESARIAL_ID
                WHERE 
                    E.ID = @id
                    AND E.EXCLUIDO = 0",
                (empresa, usuario, grupoEmpresarial) =>
                {
                    empresa.AtribuirUsuario(usuario);
                    empresa.AtribuirGrupoEmpresarial(grupoEmpresarial);
                    return empresa;
                },
                new { id }
            )
            .FirstOrDefault();
        }

        public IEnumerable<Estabelecimento> GetAllEstabelecimentos()
        {
            return _db.Database.GetDbConnection().Query<Estabelecimento, Usuario, Cnae, Empresa, Estabelecimento>(@"
                SELECT 
                    * 
                FROM
                    ESTABELECIMENTOS E
                    JOIN USUARIOS U ON U.ID = E.USUARIO_ID
                    JOIN CNAES C ON C.ID = E.CNAE_ID
                    JOIN EMPRESAS EM ON EM.ID = E.EMPRESA_ID
                WHERE
                    E.EXCLUIDO = 0
                ORDER BY 
                    E.DESCRICAO",
                (estabelecimento, usuario, cnae, empresa) =>
                {
                    estabelecimento.AtribuirUsuario(usuario);
                    estabelecimento.AtribuirCnae(cnae);
                    estabelecimento.AtribuirEmpresa(empresa);
                    return estabelecimento;
                }
            );
        }

        public Estabelecimento GetByEstabelecimentoId(Guid id)
        {
            return _db.Database.GetDbConnection().Query<Estabelecimento, Usuario, Cnae, Empresa, Estabelecimento>(@"
                SELECT 
                    * 
                FROM 
                    ESTABELECIMENTOS E
                    JOIN USUARIOS U ON U.ID = E.USUARIO_ID
                    JOIN CNAES C ON C.ID = E.CNAE_ID
                    JOIN EMPRESAS EM ON EM.ID = E.EMPRESA_ID
                WHERE 
                    E.ID = @id
                    AND E.EXCLUIDO = 0",
                (estabelecimento, usuario, cnae, empresa) =>
                {
                    estabelecimento.AtribuirUsuario(usuario);
                    estabelecimento.AtribuirCnae(cnae);
                    estabelecimento.AtribuirEmpresa(empresa);
                    return estabelecimento;
                },
                new { id }
            )
            .FirstOrDefault();
        }

        public int ObterQuantidadeDeEstabelecimentosVinculadosAoCnae(Guid id)
        {
            return _db.Database.GetDbConnection().Query<int>(@"
                SELECT
	                COUNT(1)
                FROM
	                ESTABELECIMENTOS E
                WHERE
	                E.CNAE_ID = @id
                    AND E.EXCLUIDO = 0",
                new { id }
            )
            .Single();
        }

        public int ObterQuantidadeDeEstabelecimentosVinculadosAEmpresa(Guid id)
        {
            return _db.Database.GetDbConnection().Query<int>(@"
                SELECT
	                COUNT(1)
                FROM
	                ESTABELECIMENTOS E
                WHERE
	                E.EMPRESA_ID = @id
                    AND E.EXCLUIDO = 0",
                new { id }
            )
            .Single();
        }

        public int ObterQuantidadeDeEmpresasVinculadasAoGrupoEmpresarial(Guid id)
        {
            return _db.Database.GetDbConnection().Query<int>(@"
                SELECT
	                COUNT(1)
                FROM
	                EMPRESAS E
                WHERE
	                E.GRUPO_EMPRESARIAL_ID = @id
                    AND E.EXCLUIDO = 0",
                new { id }
            )
            .Single();
        }
    }
}