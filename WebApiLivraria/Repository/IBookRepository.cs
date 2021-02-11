using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiLivraria.Models;

namespace WebApiLivraria.Repository
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAsync();
    }
}
