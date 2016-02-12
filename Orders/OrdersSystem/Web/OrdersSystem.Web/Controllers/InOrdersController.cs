namespace OrdersSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using OrdersSystem.Services.Contracts;
    using OrdersSystem.Web.Infrastructure.Mapping;
    using OrdersSystem.Web.ViewModels.InOrders;

    using Ninject;

    public class InOrdersController : Controller
    {
        [Inject]
        public IInOrdersServices InOrdersServices { get; set; }

        public ActionResult Index()
        {
            var inOrders = InOrdersServices.GetAll()
                .To<InOrderViewModel>()
                .ToList();

            return View(inOrders);
        }

        public ActionResult Details(int id)
        {
            var inOrder = this.InOrdersServices
                .GetAll()
                .Where(x => x.Id == id)
                .To<InOrderViewModel>()
                .FirstOrDefault();

            return View(inOrder);
        }

        public ActionResult Create()
        {
            return this.View();
        }
    }
}