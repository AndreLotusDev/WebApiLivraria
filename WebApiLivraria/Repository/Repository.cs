using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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

        public List<T> List()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> Numerable()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().SingleOrDefault(predicate);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }



        //Numero de rows afetadas, se salvou, mensagem de erro
        public async Task<(int, bool, string)> SaveAsync()
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var save = await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return (save, true, "Operação realizada com sucesso");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await transaction.RollbackAsync();

                return (0, false, $"O logging nao pode rastrear corretamente as alterações :{ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                await transaction.RollbackAsync();

                return (0, false, $"Error: {ex.Message}");
            }
            finally
            {
                await transaction.DisposeAsync();
            }
        }
    }
}
