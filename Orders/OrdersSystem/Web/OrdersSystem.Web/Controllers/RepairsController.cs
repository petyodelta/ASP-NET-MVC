namespace OrdersSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using Services.Contracts;
    using System.Web.Mvc;

    using Common;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Models;
    using Ninject;
    using ViewModels.Repairs;

    public class RepairsController : BaseController
    {
        [Inject]
        public IInOrdersServices InOrdersServices { get; set; }

        [Inject]
        public ICustomersServices CustomersSurvices { get; set; }

        [Inject]
        public IDevicesServices DevicesServices { get; set; }

        [Inject]
        public IUsersServices UsersServices { get; set; }

        [Inject]
        public IRolesServices RolesServices { get; set; }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName + ", " + GlobalConstants.WorkerRoleName)]
        public ActionResult Index()
        {
            var inOrders = InOrdersServices
                .GetAll()
                .Where(x => x.IsRepair == true)
                .To<RepairsViewModel>();

            return View(inOrders);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName)]
        [HttpGet]
        public ActionResult Details(int id)
        {
            var repair = this.InOrdersServices.GetById(id);
            var viewModel = this.Mapper.Map<RepairsViewModel>(repair);

            return View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName)]
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new RepairInputModel();

            viewModel.Customers = this.CustomersSurvices
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
                .ToList();
            viewModel.Devices = this.DevicesServices
                .GetAll()
                .Select(d => new SelectListItem()
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                })
                .ToList();

            var workerRoleId = this.RolesServices.GetRoleId(GlobalConstants.WorkerRoleName);

            viewModel.Workers = this.UsersServices
                .GetAll()
                .Where(w => w.Roles.Any(x => x.RoleId == workerRoleId))
                .Select(w => new SelectListItem()
                {
                    Text = w.UserName,
                    Value = w.Id.ToString()
                })
                .ToList();

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RepairInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                model.IsRepair = true;
                model.StartDate = DateTime.Now;
                model.AuthorId = User.Identity.GetUserId();
                var newRepairOrder = this.Mapper.Map<InOrder>(model);
                this.InOrdersServices.Create(newRepairOrder);

                TempData["Success"] = GlobalConstants.RepairOrderCreateNotify;
                return this.RedirectToAction("Index");
            }

            return this.View(model);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName)]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var repairOrder = this.InOrdersServices.GetById(id);
            var viewModel = this.Mapper.Map<RepairEditViewModel>(repairOrder);

            viewModel.Customers = this.CustomersSurvices
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
                .ToList();
            viewModel.Devices = this.DevicesServices
                .GetAll()
                .Select(d => new SelectListItem()
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                })
                .ToList();

            var workerRoleId = this.RolesServices.GetRoleId(GlobalConstants.WorkerRoleName);

            viewModel.Workers = this.UsersServices
                .GetAll()
                .Where(w => w.Roles.Any(x => x.RoleId == workerRoleId))
                .Select(w => new SelectListItem()
                {
                    Text = w.UserName,
                    Value = w.Id.ToString()
                })
                .ToList();

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RepairEditViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var repair = this.Mapper.Map<InOrder>(model);
                this.InOrdersServices.Update(model.Id, repair);

                TempData["Success"] = GlobalConstants.RepairOrderUpdateNotify;
                return this.RedirectToAction("Details", new { id = model.Id });
            }

            return this.View(model);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName + ", " + GlobalConstants.WorkerRoleName)]
        [HttpGet]
        public ActionResult GetFullDescription(int id)
        {
            var repairOrder = this.InOrdersServices.GetById(id);
            var description = repairOrder.Description;

            return this.Content(description);
        }
    }
}