namespace OrdersSystem.Data
{
    using OrdersSystem.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IOrdersDbContext
    {
        IDbSet<Category> Categories { get; set; }

        IDbSet<Order> Orders { get; set; }

        IDbSet<Device> Devices { get; set; }

        IDbSet<Customer> Customers { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
