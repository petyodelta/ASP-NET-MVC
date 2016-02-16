namespace OrdersSystem.Services.Contracts
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Linq;

    public interface IRolesServices
    {
        IQueryable<IdentityRole> All();

        void AddRoleToUser(string userId, string roleId);

        void RemoveUserRole(string userId, string roleId);

        string GetRoleNameById(string roleId);

        ICollection<IdentityUserRole> GetUserRoles(string id);
    }
}
