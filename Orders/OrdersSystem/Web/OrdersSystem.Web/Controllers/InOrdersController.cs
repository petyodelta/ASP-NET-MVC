﻿namespace OrdersSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using OrdersSystem.Services.Contracts;
    using OrdersSystem.Web.Infrastructure.Mapping;
    using OrdersSystem.Web.ViewModels.InOrders;

    using Ninject;
    using Models;
    using System;
    using Microsoft.AspNet.Identity;
    using Common;

    public class InOrdersController : BaseController
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
                .Where(x => x.IsRepair == false)
                .To<InOrderViewModel>();

            return View(inOrders);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName)]
        public ActionResult Details(int id)
        {
            var inOrder = this.InOrdersServices.GetById(id);
            var viewModel = this.Mapper.Map<InOrderViewModel>(inOrder);
            
            return View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName)]
        [HttpGet]
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

            var workerRoleId = this.RolesServices.GetRoleId("Worker");

            newOrder.Workers = this.UsersServices
                .GetAll()
                .Where( w => w.Roles.Any(x => x.RoleId == workerRoleId))
                .Select(w => new SelectListItem()
                {
                    Text = w.UserName,
                    Value = w.Id.ToString()
                })
                .ToList();            
           
            return this.View(newOrder);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InOrderInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                model.IsRepair = false;
                model.StartDate = DateTime.Now;
                model.AuthorId = User.Identity.GetUserId();
                var newInOrder = this.Mapper.Map<InOrder>(model);
                this.InOrdersServices.Create(newInOrder);

                TempData["Success"] = "Incoming order created";
                return this.RedirectToAction("Index");
            }

            return this.View("Create", model);            
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName)]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var inOrder = this.InOrdersServices.GetById(id);
            var viewModel = this.Mapper.Map<InOrderEditViewModel>(inOrder);

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

        [Authorize(Roles = GlobalConstants.AdministratorRoleName + ", " + GlobalConstants.BossRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InOrderEditViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var inOrder = this.Mapper.Map<InOrder>(model);
                this.InOrdersServices.Update(model.Id, inOrder);
                TempData["Success"] = "Incoming order updated";
                return this.RedirectToAction("Details", new { id = model.Id });
            }

            return this.View("Edit", model);           
        }
    }
}