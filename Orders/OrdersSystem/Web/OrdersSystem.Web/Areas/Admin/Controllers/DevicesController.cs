namespace OrdersSystem.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Common;
    using OrdersSystem.Services.Contracts;
    using OrdersSystem.Web.Infrastructure.Mapping;
    using Models;
    using Ninject;
    using Web.Controllers;
    using ViewModels.Devices;
    
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class DevicesController : BaseController
    {
        [Inject]
        public IDevicesServices DevicesServices { get; set; }

        [Inject]
        public ICategoriesServices CategoriesServices { get; set; }

        public ActionResult Index()
        {
            var viewModel = this.DevicesServices
               .GetAll()
               .To<DeviceViewModel>();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new DeviceInputModel();
            viewModel.Categories = this.CategoriesServices
                .GetAll()
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
                .ToList();

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(DeviceInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                var deviceName = this.DevicesServices
                    .GetAll()
                    .FirstOrDefault(x => x.Name.ToLower() == model.Name.ToLower());
                if (deviceName == null)
                {
                    var newDevice = this.Mapper.Map<Device>(model);
                    this.DevicesServices.Add(newDevice);

                    TempData["Success"] = GlobalConstants.DeviceAddNotify;                    
                }
                else
                {
                    TempData["Warning"] = GlobalConstants.DeviceExistsNotify;
                }

                return this.Redirect("/Admin/Devices/Index");
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var viewModel = this.DevicesServices
                .GetAll()
                .Where(x => x.Id == id)
                .To<DeviceEditModel>()
                .FirstOrDefault();

            viewModel.Categories = this.CategoriesServices
                .GetAll()
                .Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
                .ToList();

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DeviceEditModel model)
        {
            if (this.ModelState.IsValid)
            {
                var device = this.Mapper.Map<Device>(model);
                this.DevicesServices.Update(model.Id, device);
                TempData["Success"] = GlobalConstants.DeviceUpdateNotify;

                return this.Redirect("/Admin/Devices/Index");
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            this.DevicesServices.Delete(id);
            TempData["Success"] = GlobalConstants.DeviceDeletedNotify;
            return this.Redirect("/Admin/Devices/Index");
        }
    }
}