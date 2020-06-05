using Confitec.Data.Context;
using Confitec.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Confitec.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DataContext Db;
        protected DbSet<T> DbSet;

        public Repository([FromServices]DataContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public virtual EntityEntry<T> Add(T obj)
        {
            var returnObj = DbSet.Add(obj);
            return returnObj;
        }

        public virtual T GetById(int id)
        {
            var returnObj = DbSet.Find(id);

            if(returnObj != null)
                Db.Entry(returnObj).State = EntityState.Detached;

            return returnObj;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbSet.ToList(); 
        }

        public virtual T Update(T obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            return obj;
        }

        public virtual void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
