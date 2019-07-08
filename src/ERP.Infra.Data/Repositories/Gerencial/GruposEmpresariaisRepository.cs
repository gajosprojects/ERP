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
                    AND GE.ATIVO = 1
                ORDER BY 
                    GE.DESCRICAO",
                (grupoEmpresarial, usuario) =>
                {
                    grupoEmpresarial.AtribuirUsuario(usuario);
                    return grupoEmpresarial;
                }, 
                new { id }
            )
            .FirstOrDefault();
        }
    }
}