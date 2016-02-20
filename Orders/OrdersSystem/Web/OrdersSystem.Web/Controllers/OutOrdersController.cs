namespace OrdersSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using OrdersSystem.Web.Infrastructure.Mapping;
    using Ninject;
    using Services.Contracts;
    using ViewModels.OutOrders;
    using System;
    using Models;
    using Microsoft.AspNet.Identity;
    using Common;
    public class OutOrdersController : BaseController
    {
        [Inject]
        public IOutOrdersServices OutOrdersServices { get; set; }

        [Inject]
        public IUsersServices UsersServices { get; set; }

        [Inject]
        public ISuppliersServices SuppliersServices { get; set; }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName + ", " + GlobalConstants.WorkerRoleName)]
        public ActionResult Index()
        {
            var outOrders = this.OutOrdersServices
                .GetAll()
                .To<OutOrderViewModel>();

            return View(outOrders);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName)]
        [HttpGet]
        public ActionResult Details(int id)
        {
            var outOrder = this.OutOrdersServices.GetById(id);
            var viewModel = this.Mapper.Map<OutOrderViewModel>(outOrder);

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName)]
        [HttpGet]
        public ActionResult Create()
        {
            var newOrder = new OutOrderInputModel();

            newOrder.Suppliers = this.SuppliersServices
                .GetAll()
                .Select(s => new SelectListItem()
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                })
                .ToList();            

            return this.View(newOrder);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OutOrderInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                model.StartDate = DateTime.Now;
                model.AuthorId = User.Identity.GetUserId();
                var newOutOrder = this.Mapper.Map<OutOrder>(model);
                this.OutOrdersServices.Create(newOutOrder);

                TempData["Success"] = "Supply order created";
                return this.RedirectToAction("Index");
            }

            return this.View("Create", model);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName)]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var outOrder = this.OutOrdersServices.GetById(id);
            var viewModel = this.Mapper.Map<OutOrderEditViewModel>(outOrder);

            viewModel.Suppliers = this.SuppliersServices
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
                .ToList();
            viewModel.Authors = this.UsersServices
                .GetAll()
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
        public ActionResult Edit(OutOrderEditViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var outOrder = this.Mapper.Map<OutOrder>(model);
                this.OutOrdersServices.Update(model.Id, outOrder);

                TempData["Success"] = "Outgoing order edited";
                return this.RedirectToAction("Details", new { id = model.Id });
            }

            return this.View("Edit", model);
        }
    }
}