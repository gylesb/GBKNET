using Microsoft.EntityFrameworkCore; 

namespace GBKNet.Models
{
    public class GBKNetContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        //public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseMySql(@"Server=localhost;Port=8889;database=GummiBear;uid=root;pwd=root;");
    }
}