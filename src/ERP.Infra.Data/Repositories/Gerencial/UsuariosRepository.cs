using Dapper;
using ERP.Gerencial.Domain.Usuarios;
using ERP.Gerencial.Domain.Usuarios.Repositories;
using ERP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERP.Infra.Data.Repositories.Gerencial
{
    public class UsuariosRepository : Repository<Usuario>, IUsuariosRepository
    {
        public UsuariosRepository(GruposEmpresariaisContext db) : base(db)
        {
        }

        public override IEnumerable<Usuario> GetAll()
        {
            return _db.Database.GetDbConnection().Query<Usuario>(@"
                SELECT 
                    * 
                FROM
                    USUARIOS U
                WHERE
                    U.ATIVO = 1
                ORDER BY 
                    U.NOME,
                    U.SOBRENOME"
            );
        }

        public override Usuario GetById(Guid id)
        {
            return _db.Database.GetDbConnection().Query<Usuario>(@"
                SELECT 
                    * 
                FROM
                    USUARIOS U
                WHERE
                    U.ATIVO = 1
                    AND U.ID = @id
                ORDER BY 
                    U.NOME,
                    U.SOBRENOME",
                new { id }
            )
            .FirstOrDefault();
        }
    }
}
