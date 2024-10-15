using Data.Models;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data.Models;

namespace Data{
    public class AppDbContext:DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }
    }
}