namespace OrdersSystem.Services.Contracts
{
    using System.Linq;
    using OrdersSystem.Models;
    
    public interface ISuppliersServices
    {
        IQueryable<Supplier> GetAll();
    }
}
