using Microsoft.EntityFrameworkCore;
using TestTask.DataAccess.Entities;

namespace TestTask.DataAccess
{
    public class TestTaskDbContext : DbContext
    {       
        public TestTaskDbContext(DbContextOptions<TestTaskDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(e => e.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(e => e.UserName).IsUnique();
        }
    }
}
