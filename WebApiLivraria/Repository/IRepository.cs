using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApiLivraria.Repository
{
    public interface IRepository<T>
    {
        //LISTAGEM
        IQueryable<T> Get();
        IEnumerable<T> Numerable();
        List<T> List();

        //FUNCOES UNIVERSAIS
        T GetById(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<(int, bool, string)> SaveAsync();
    }
}
