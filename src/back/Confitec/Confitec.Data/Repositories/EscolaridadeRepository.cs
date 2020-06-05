using Confitec.Data.Context;
using Confitec.Domain.Entities;
using Confitec.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Data.Repositories
{
    public class EscolaridadeRepository : Repository<Escolaridade>, IEscolaridadeRepository
    {
        public EscolaridadeRepository(DataContext dataContext)
            : base(dataContext)
        {

        }
    }
}
