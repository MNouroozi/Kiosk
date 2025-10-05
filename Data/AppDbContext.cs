using Microsoft.EntityFrameworkCore;

namespace Kiosk.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } // جدول نمونه
    }

    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
