namespace OrdersSystem.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    using Common;
    using Infrastructure.Mapping;
    using Ninject;
    using OrdersSystem.Services.Contracts;
    using ViewModels.Categories;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class CategoriesController : BaseController
    {
        [Inject]
        public ICategoriesServices CategoriesServices { get; set; }

        public ActionResult Index()
        {
            var viewModel = this.CategoriesServices.GetAll().To<CategoryViewModel>();
            return View(viewModel);
        }
    }
}