using Microsoft.EntityFrameworkCore;

namespace basic_webapi.Datas
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Type> Types { get; set; }
    }
}
