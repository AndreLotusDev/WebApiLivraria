using Microsoft.EntityFrameworkCore;
using WebApiLivraria.Models;

namespace WebApiLivraria.Data
{
    public class FluentApi
    {
        public void SetFluentApiConfig(ModelBuilder builder) 
        {
            //BOOK
            builder.Entity<Book>().Property(b => b.Author).HasMaxLength(150).IsRequired();

            builder.Entity<Book>().Property(b => b.Title).HasMaxLength(150).IsRequired();

            builder.Entity<Book>().Property(b => b.Publisher).HasMaxLength(100);

            builder.Entity<Book>().Property(b => b.Description).HasMaxLength(300).IsRequired().HasDefaultValue("Descrição: ");

            builder.Entity<Book>().Property(b => b.FileUrl).IsRequired();
            builder.Entity<Book>().Property(b => b.ImageUrl).IsRequired();

            builder.Entity<Book>().Property(b => b.Year).HasColumnType("SMALLINT");
            //--------------
        }
    }
}
