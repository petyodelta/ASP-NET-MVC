namespace OrdersSystem.Services
{
    using System.Linq;
    using OrdersSystem.Models;
    using OrdersSystem.Services.Contracts;
    using Data.Repository;
    using System;

    public class UsersServices : IUsersServices
    {
        private IRepository<User> users;

        public UsersServices(IRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All().OrderBy(x => x.UserName);
        }

        public User GetById(string id)
        {
            return this.users.GetById(id);
        }

        public User Update(string id, string email)
        {
            var user = this.users.GetById(id);
            
            user.Email = email;
            user.UserName = email;

            this.users.SaveChanges();
            return user;
        }
    }
}
