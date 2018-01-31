using Microsoft.EntityFrameworkCore;

namespace GBKNet.Models
{
    public class GBKNetDbContext : DbContext
    {
        public GBKNetDbContext()
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=ToDoListWithMigrations;uid=root;pwd=root;");
        }

        public GBKNetDbContext(DbContextOptions<GBKNetDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}