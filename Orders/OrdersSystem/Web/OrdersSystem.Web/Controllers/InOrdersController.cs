namespace OrdersSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using OrdersSystem.Services.Contracts;
    using OrdersSystem.Web.Infrastructure.Mapping;
    using OrdersSystem.Web.ViewModels.InOrders;
    using Microsoft.AspNet.Identity;

    using Ninject;

    public class InOrdersController : Controller
    {
        [Inject]
        public IInOrdersServices InOrdersServices { get; set; }

        [Inject]
        public ICustomersServices CustomersSurvices { get; set; }

        [Inject]
        public IDevicesServices DevicesServices { get; set; }

        [Inject]
        public IUsersServices UsersServices { get; set; }

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
            var newOrder = new InOrderInputModel();
            newOrder.Customers = this.CustomersSurvices
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
                .ToList();
            newOrder.Devices = this.DevicesServices
                .GetAll()
                .Select(d => new SelectListItem()
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                })
                .ToList();
            newOrder.Authors = this.UsersServices
                .GetAll()
                .Where(u => u.Roles.Any(r => r.RoleId == "320260dd-421b-41d1-ae01-3a78a5d2d459"))
                .Select(a => new SelectListItem()
                {
                    Text = a.UserName,
                    Value = a.Id.ToString()
                })
                .ToList();
            newOrder.Workers = this.UsersServices
                .GetAll()
                .Select(w => new SelectListItem()
                {
                    Text = w.UserName,
                    Value = w.Id.ToString()
                })
                .ToList();
            
           
            return this.View(newOrder);
        }
    }
}