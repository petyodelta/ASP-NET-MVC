namespace OrdersSystem.Services.Contracts
{
    using System.Linq;
    using OrdersSystem.Models;

    public interface ICustomersServices
    {
        IQueryable<Customer> GetAll();
    }
}
