using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using WebApiLivraria.Data;

namespace WebApiLivraria.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().SingleOrDefault(predicate);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
