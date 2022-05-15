using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models
{
    public class DbLibraryContext : DbContext
    {
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<AuthorBook> AuthorBooks { get; set; }
        public virtual DbSet<Magazine> Magazines { get; set; }  
        public virtual DbSet<Categories> Categories { get; set; }
        public DbLibraryContext(DbContextOptions<DbLibraryContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
