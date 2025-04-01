using Microsoft.EntityFrameworkCore;
using moontest1.Models;

namespace moontest1.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }
    }
}
