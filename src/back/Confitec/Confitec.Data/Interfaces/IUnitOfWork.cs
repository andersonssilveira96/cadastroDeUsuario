using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        void BeginTransaction();
    }
}
