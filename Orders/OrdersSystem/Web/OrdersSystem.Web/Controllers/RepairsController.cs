namespace OrdersSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using Services.Contracts;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Models;
    using Ninject;
    using Infrastructure.Mapping;
    using ViewModels.Repairs;
    using Common;
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
            var newRepair = new RepairInputModel();

            newRepair.Customers = this.CustomersSurvices
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
                .ToList();
            newRepair.Devices = this.DevicesServices
                .GetAll()
                .Select(d => new SelectListItem()
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                })
                .ToList();
            newRepair.Workers = this.UsersServices
                .GetAll()
                .Select(w => new SelectListItem()
                {
                    Text = w.UserName,
                    Value = w.Id.ToString()
                })
                .ToList();

            return this.View(newRepair);
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
            viewModel.Workers = this.UsersServices
                .GetAll()
                .Select(w => new SelectListItem()
                {
                    Text = w.UserName,
                    Value = w.Id.ToString()
                })
                .ToList();

            return this.View(viewModel);
        }
    }
}