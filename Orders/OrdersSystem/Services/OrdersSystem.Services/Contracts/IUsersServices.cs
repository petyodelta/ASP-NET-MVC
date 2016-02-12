namespace OrdersSystem.Services.Contracts
{
    using System.Linq;
    using OrdersSystem.Models;
    
    public interface IUsersServices
    {
        IQueryable<User> GetAll();
    }
}
