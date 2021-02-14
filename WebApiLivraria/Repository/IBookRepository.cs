using ModelsShared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiLivraria.Repository
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAsync();
    }
}
