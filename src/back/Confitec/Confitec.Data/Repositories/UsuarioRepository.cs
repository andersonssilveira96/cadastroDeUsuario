using Confitec.Data.Context;
using Confitec.Domain.Entities;
using Confitec.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DataContext dataContext)
            :base(dataContext)
        {

        }

        public override IEnumerable<Usuario> GetAll()
        {
            return DbSet.Include(c => c.Escolaridade).ToList();
        }
      
    }
}
