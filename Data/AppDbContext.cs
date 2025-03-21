using Microsoft.EntityFrameworkCore;
using moontest1.Models;

namespace moontest1.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        //public DbSet<User> Users { get; set; }
       // public DbSet<Item> Items { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }
    }
}
