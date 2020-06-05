using Confitec.Data.Context;
using Confitec.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Data.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _dataContext;
        private bool _disposed;

        public UnitOfWork([FromServices]DataContext dataContext)
        {
            _dataContext = dataContext;
        }      

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _dataContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);            
        }
    }
}
