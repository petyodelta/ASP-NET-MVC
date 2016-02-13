namespace OrdersSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using OrdersSystem.Web.Infrastructure.Mapping;
    using Ninject;
    using Services.Contracts;
    using ViewModels.OutOrders;

    public class OutOrdersController : BaseController
    {
        [Inject]
        public IOutOrdersServices OutOrdersServices { get; set; }

        public ActionResult Index()
        {
            var outOrders = this.OutOrdersServices
                .GetAll()
                .To<OutOrderViewModel>()
                .ToList();

            return View(outOrders);
        }
    }
}