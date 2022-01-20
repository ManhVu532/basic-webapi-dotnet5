using Microsoft.EntityFrameworkCore;

namespace basic_webapi.Datas
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey("Id");
                e.Property(o => o.CreateAt).HasDefaultValueSql("getutcdate()");
                e.Property(o => o.ReceiverName).IsRequired().HasMaxLength(100);
            });

            builder.Entity<OrderDetail>(e =>
            {
                e.ToTable("OrderDetail");
                e.HasKey(e => new { e.OrderId, e.ProductId });
                e.HasOne(e => e.Order)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.OrderId)
                .HasForeignKey("FK_OrderDetail_Order");

                e.HasOne(e => e.Product)
                .WithMany(e => e.OrderDetails)
               .HasForeignKey(e => e.ProductId)
               .HasForeignKey("FK_OrderDetail_Product");
            });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
