using IntroAPIProject.Models;
using Microsoft.EntityFrameworkCore;
using moontest1.Models;

namespace moontest1.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        //db sets (list of objects from the db)
        public DbSet<Item> Item { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}
