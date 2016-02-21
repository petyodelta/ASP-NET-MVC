namespace OrdersSystem.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using OrdersSystem.Services.Contracts;
    using OrdersSystem.Web.Infrastructure.Mapping;
    using Ninject;
    using Web.Controllers;
    using ViewModels.Devices;

    public class DevicesController : BaseController
    {
        [Inject]
        public IDevicesServices DevicesServices { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 1 * 60)]
        [ChildActionOnly]
        public ActionResult CacheDevices()
        {
            var devices = this.DevicesServices
                .GetAll()
                .To<DeviceViewModel>();

            return this.PartialView("_AllDevicesPartial", devices);
        }
    }
}