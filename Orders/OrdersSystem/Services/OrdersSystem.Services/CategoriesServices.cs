namespace OrdersSystem.Services
{
    using System.Linq;
    using OrdersSystem.Models;
    using OrdersSystem.Services.Contracts;
    using Data.Repository;

    public class CategoriesServices : ICategoriesServices
    {
        private IRepository<Category> categories;

        public CategoriesServices(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public IQueryable<Category> GetAll()
        {
            return this.categories.All().OrderBy(x => x.Name);
        }
    }
}
