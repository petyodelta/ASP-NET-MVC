namespace OrdersSystem.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Common;
    using OrdersSystem.Web.Controllers;
    using Services.Contracts;
    using Infrastructure.Mapping;
    using ViewModels.Customers;
    using Models;
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class CustomersController : BaseController
    {
        private readonly ICustomersServices customers;

        public CustomersController(ICustomersServices customersServices)
        {
            this.customers = customersServices;
        }

        public ActionResult Index()
        {
            var viewModel = this.customers.GetAll().To<CustomerViewModel>();
            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CustomerInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                var customerName = this.customers
                    .GetAll()
                    .FirstOrDefault(x => x.Name.ToLower() == model.Name.ToLower());
                if (customerName == null)
                {
                    var customer = this.Mapper.Map<Customer>(model);
                    this.customers.Add(customer);
                    TempData["Success"] = GlobalConstants.CustomerAddNotify;
                }
                else
                {
                    TempData["Warning"] = GlobalConstants.CustomerExistsNotify;
                }

                return this.Redirect("/Admin/Customers/Index");
            }

            return this.View(model);
        }
    }
}