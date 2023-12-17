using Microsoft.EntityFrameworkCore;
using ServiceOrders.Models.DTO.ServiceInOrder;
using ServiceOrders.Models.Order;
using ServiceOrders.Models.Service;
using ServiceOrders.Models.Users;

namespace ServiceOrders.Repository
{
    public class ServiceOrdersDbContext : DbContext
    {
        public ServiceOrdersDbContext(DbContextOptions<ServiceOrdersDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ServiceInOrder> ServicesInOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ServiceInOrder>()
                .HasKey(nameof(ServiceInOrder.OrderId), nameof(ServiceInOrder.ServiceId));
        }
    }
}
