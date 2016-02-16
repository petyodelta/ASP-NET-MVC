namespace OrdersSystem.Services
{
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using OrdersSystem.Services.Contracts;
    using Microsoft.AspNet.Identity;
    using Data;
    using System.Collections.Generic;

    public class RolesServices : IRolesServices
    {
        private IOrdersData data;

        public RolesServices(IOrdersData data)
        {
            this.data = data;
        }


        public IQueryable<IdentityRole> All()
        {
            return this.data.RolesManager.Roles;
        }

        public string GetRoleNameById(string roleId)
        {
            var roleName = this.data.RolesManager.Roles.FirstOrDefault(r => r.Id == roleId).Name;
            return roleName;
        }

        public void AddRoleToUser(string userId, string roleId)
        {
            var roleName = this.GetRoleNameById(roleId);
            var role = this.data.UserManager.AddToRole(userId, roleName);
        }

        public void RemoveUserRole(string userId, string roleId)
        {
            var roleName = this.GetRoleNameById(roleId);
            this.data.UserManager.RemoveFromRole(userId, roleName);
        }

        public ICollection<IdentityUserRole> GetUserRoles(string id)
        {
            return this.data.Users.GetById(id).Roles;
        }
    }
}
