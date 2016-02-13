namespace OrdersSystem.Services
{
    using System;
    using System.Linq;
    using Contracts;
    using Data.Repository;
    using Models;
    
    public class SuppliersServices : ISuppliersServices
    {
        private IRepository<Supplier> suppliers;

        public SuppliersServices(IRepository<Supplier> suppliers)
        {
            this.suppliers = suppliers;
        }
        
        public IQueryable<Supplier> GetAll()
        {
            return this.suppliers.All().OrderBy(s => s.Name);
        }
    }
}
