namespace OrdersSystem.Web.Controllers
{
    using System.Linq;
    using Services.Contracts;
    using System.Web.Mvc;
    using Ninject;

    public class OutOrdersController : BaseController
    {
        [Inject]
        public IOutOrdersServices OutOrdersServices { get; set; }

        public ActionResult Index()
        {
            var outOrders = this.OutOrdersServices
                .GetAll()
                .ToList();

            return View(outOrders);
        }
    }
}