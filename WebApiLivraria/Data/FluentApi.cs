using Microsoft.EntityFrameworkCore;
using WebApiLivraria.Models;

namespace WebApiLivraria.Data
{
    public class FluentApi
    {
        public void SetFluentApiConfig(ModelBuilder builder) 
        {
            builder.Entity<Book>().Property(b => b.Author).HasMaxLength(150).IsRequired();

            builder.Entity<Book>().Property(b => b.Title).HasMaxLength(150).IsRequired();

            builder.Entity<Book>().Property(b => b.Publisher).HasMaxLength(100);
        }
    }
}
