using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelsShared.Models;

namespace WebApiLivraria.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //USER - SECTION
            builder.Entity<User>().Property(p => p.Name).IsRequired();
            builder.Entity<User>().Property(p => p.Password).IsRequired();

            //CATEGORIES - SECTION
            builder.Entity<Categories>().Property(p => p.Description).IsRequired();
            builder.Entity<Categories>().Property(p => p.Name).IsRequired();
            //Colocar que a role é obrigatoria
        }

        public override int SaveChanges()
        {
            //CATEGORIES - SECTION
            foreach (var entry in ChangeTracker.Entries<Categories>())
            {
                if (entry.State == EntityState.Modified || entry.State == EntityState.Added)
                {
                    entry.Entity.Name = entry.Entity.Name.ToUpper();
                }
            }
            //-----------------------------------------
            return base.SaveChanges();
        }
    }
}
