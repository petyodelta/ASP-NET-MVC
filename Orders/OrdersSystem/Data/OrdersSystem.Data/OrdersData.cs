using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OrdersSystem.Models;
using OrdersSystem.Data.Repository;

namespace OrdersSystem.Data
{
    public class OrdersData : IOrdersData
    {
        private OrdersDbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public OrdersData()
            : this(new OrdersDbContext())
        {
        }

        public OrdersData(OrdersDbContext context)
        {
            this.context = context;
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public RoleManager<IdentityRole> RolesManager
        {
            get
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var rolesManager = new RoleManager<IdentityRole>(roleStore);
                return rolesManager;
            }
        }

        public UserManager<User> UserManager
        {
            get
            {
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                return userManager;
            }
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
