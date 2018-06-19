using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PrestadorServico.Repositories
{
    public abstract class GenericRepository<C, T> :
        IGenericRepository<T> where T : class where C : DbContext, new()
    {
        private C _entities = new C();
        public C Context
        {

            get { return _entities; }
            set { _entities = value; }
        }

        public virtual void Add(T entity)
        {
            _entities.Set<T>().Add(entity);
            _entities.SaveChanges();
        }

        public abstract T Get(int id);

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public virtual void Remove(T entity)
        {
            _entities.Set<T>().Remove(entity);
            _entities.SaveChanges();
        }
    }
}