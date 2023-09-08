using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkWork.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { 
            Database.EnsureCreated();   // создем БД при первом обращении
        }
    }
}
