namespace OrdersSystem.Services
{
    using System;
    using System.Linq;
    using OrdersSystem.Models;
    using OrdersSystem.Services.Contracts;
    using Data.Repository;

    public class InOrdersServices : IInOrdersServices
    {
        private IRepository<InOrder> inOrders;

        public InOrdersServices(IRepository<InOrder> inOrders)
        {
            this.inOrders = inOrders;
        }

        public InOrder Create(InOrder newInOrder)
        {
            this.inOrders.Add(newInOrder);
            this.inOrders.SaveChanges();

            return newInOrder;
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<InOrder> GetAll()
        {
            return this.inOrders.All().OrderByDescending(x => x.Id);
        }

        public InOrder GetById(int id)
        {
            return this.inOrders.GetById(id);
        }

        public InOrder Update(int id, InOrder outOrder)
        {
            throw new NotImplementedException();
        }
    }
}
