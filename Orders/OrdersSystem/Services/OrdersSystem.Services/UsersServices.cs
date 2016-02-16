namespace OrdersSystem.Services
{
    using System.Linq;
    using OrdersSystem.Models;
    using OrdersSystem.Services.Contracts;
    using Data.Repository;

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
    }
}
