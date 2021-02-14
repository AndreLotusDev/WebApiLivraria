using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelsShared.Models;

namespace WebApiLivraria.Data
{
    public class ApplicationContext : IdentityDbContext<UsuarioContext, IdentityRole, string>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<UserPattherns> UserPattherns { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UsuarioContext>().ToTable("Usuarios");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UsuarioRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UsuarioClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("RegistroLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UsuarioTokens");
        }
    }
}
