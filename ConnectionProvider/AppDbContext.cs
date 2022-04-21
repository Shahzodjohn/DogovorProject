using Entity;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConnectionProvider
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> users { get; set; }
        public DbSet<Department> departments { get; set; }
    }
}