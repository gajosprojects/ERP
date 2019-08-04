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
                    GE.ATIVO = 1
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
                    AND GE.ATIVO = 1",
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
                    C.ATIVO = 1
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
                    AND C.ATIVO = 1",
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
            return _db.Database.GetDbConnection().Query<Empresa, Usuario, Empresa>(@"
                SELECT 
                    * 
                FROM
                    EMPRESAS E
                    JOIN USUARIOS U ON U.ID = E.USUARIO_ID
                WHERE
                    E.ATIVO = 1
                ORDER BY 
                    E.DESCRICAO",
                (empresa, usuario) =>
                {
                    empresa.AtribuirUsuario(usuario);
                    return empresa;
                }
            );
        }

        public Empresa GetByEmpresaId(Guid id)
        {
            return _db.Database.GetDbConnection().Query<Empresa, Usuario, Empresa>(@"
                SELECT 
                    * 
                FROM 
                    EMPRESAS E
                    JOIN USUARIOS U ON U.ID = E.USUARIO_ID
                WHERE 
                    E.ID = @id
                    AND E.ATIVO = 1",
                (empresa, usuario) =>
                {
                    empresa.AtribuirUsuario(usuario);
                    return empresa;
                },
                new { id }
            )
            .FirstOrDefault();
        }

        public IEnumerable<Estabelecimento> GetAllEstabelecimentos()
        {
            return _db.Database.GetDbConnection().Query<Estabelecimento, Usuario, Estabelecimento>(@"
                SELECT 
                    * 
                FROM
                    ESTABELECIMENTOS E
                    JOIN USUARIOS U ON U.ID = E.USUARIO_ID
                WHERE
                    E.ATIVO = 1
                ORDER BY 
                    E.DESCRICAO",
                (estabelecimento, usuario) =>
                {
                    estabelecimento.AtribuirUsuario(usuario);
                    return estabelecimento;
                }
            );
        }

        public Estabelecimento GetByEstabelecimentoId(Guid id)
        {
            return _db.Database.GetDbConnection().Query<Estabelecimento, Usuario, Estabelecimento>(@"
                SELECT 
                    * 
                FROM 
                    ESTABELECIMENTOS E
                    JOIN USUARIOS U ON U.ID = E.USUARIO_ID
                WHERE 
                    E.ID = @id
                    AND E.ATIVO = 1",
                (estabelecimento, usuario) =>
                {
                    estabelecimento.AtribuirUsuario(usuario);
                    return estabelecimento;
                },
                new { id }
            )
            .FirstOrDefault();
        }
    }
}