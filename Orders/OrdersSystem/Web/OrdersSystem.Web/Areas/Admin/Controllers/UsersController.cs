namespace OrdersSystem.Web.Areas.Admin.Controllers
{
    using Infrastructure.Mapping;
    using Ninject;
    using Services.Contracts;
    using System.Web.Mvc;
    using ViewModels;
    public class UsersController : Controller
    {
        [Inject]
        public IUsersServices UsersServices { get; set; }

        [Inject]
        public IRolesServices RolesServices { get; set; }

        public ActionResult Index()
        {
            var users = this.UsersServices.GetAll().To<UserViewModel>();

            return View(users);
        }
    }
}