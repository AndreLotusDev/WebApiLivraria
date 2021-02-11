using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApiLivraria.Data;
using WebApiLivraria.Models;

namespace WebApiLivraria.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Book>> GetAsync()
        {
            return await _context.Books.ToListAsync();
        }
    }
}
