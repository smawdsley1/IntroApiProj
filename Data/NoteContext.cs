using Microsoft.EntityFrameworkCore;
using moontest1.Models;

namespace moontest1.Data
{
    public class NoteContext : DbContext
    {
        public string ConnectionString = "Server=locahost,1433;Initial Catalog=cloud-project-db;Persist Security Info=False;User ID=service;Password=WildCat123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            ob.UseSqlServer(ConnectionString);
        } 

        public DbSet<Note> Note { get; set; }
    }
}
