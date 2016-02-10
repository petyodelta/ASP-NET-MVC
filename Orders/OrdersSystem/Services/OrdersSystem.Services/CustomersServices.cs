namespace OrdersSystem.Services
{
    using System.Linq;
    using Data.Repository;
    using OrdersSystem.Models;
    using OrdersSystem.Services.Contracts;
    
    public class CustomersServices : ICustomersServices
    {
        private IRepository<Customer> customers;

        public CustomersServices(IRepository<Customer> customers)
        {
            this.customers = customers;
        }

        public IQueryable<Customer> GetAll()
        {
            return this.customers.All().OrderBy(x => x.Name);
        }
    }
}
