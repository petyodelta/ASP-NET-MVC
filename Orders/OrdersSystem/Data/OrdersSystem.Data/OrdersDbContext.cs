using Microsoft.AspNet.Identity.EntityFramework;
using OrdersSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersSystem.Data
{
    public class OrdersDbContext : IdentityDbContext<User>
    {
        public OrdersDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static OrdersDbContext Create()
        {
            return new OrdersDbContext();
        }
    }
}
