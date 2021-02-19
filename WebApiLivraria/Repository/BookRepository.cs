using Microsoft.EntityFrameworkCore;
using ModelsShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApiLivraria.Data;

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

        public async Task<IEnumerable<Book>> GetTopBooks()
        {
            return await _context.Books.Take(10).ToListAsync();
        }
    }
}
