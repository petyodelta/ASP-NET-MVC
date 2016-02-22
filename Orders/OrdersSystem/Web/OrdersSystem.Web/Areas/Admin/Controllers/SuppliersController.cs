namespace OrdersSystem.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    using Ninject;
    using Infrastructure.Mapping;
    using Services.Contracts;
    using ViewModels.Suppliers;
    
    public class SuppliersController : Controller
    {
        [Inject]
        public ISuppliersServices SuppliersServices { get; set; }

        public ActionResult Index()
        {
            var viewModel = this.SuppliersServices
                .GetAll()
                .To<SupplierViewModel>();

            return View(viewModel);
        }
    }
}