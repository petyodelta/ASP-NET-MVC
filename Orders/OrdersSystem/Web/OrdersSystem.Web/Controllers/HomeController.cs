namespace OrdersSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using OrdersSystem.Services.Contracts;
    using OrdersSystem.Web.Infrastructure.Mapping;
    using Ninject;
    using ViewModels.InOrders;
    public class HomeController : Controller
    {
        [Inject]
        public IInOrdersServices InOrdersServices { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 1 * 60)]
        [ChildActionOnly]
        public ActionResult CacheHome()
        {
            var inOrders = this.InOrdersServices
                .GetAll()
                .OrderByDescending(x => x.EndDate)
                .Take(6)
                .To<InOrderViewModel>()
                .ToList();

            return this.PartialView("_CacheHomePartial", inOrders);
        }       
    }
}