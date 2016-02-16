namespace OrdersSystem.Data
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using OrdersSystem.Models;
    using System;

    public interface IOrdersData : IDisposable
    {
        RoleManager<IdentityRole> RolesManager { get; }

        UserManager<User> UserManager { get; }
    }
}
