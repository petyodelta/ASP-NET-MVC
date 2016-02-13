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

        public ActionResult Index()
        {
            var inOrders = InOrdersServices
                .GetAll()
                .To<InOrderViewModel>();

            return View(inOrders);
        }

        public ActionResult Details(int id)
        {
            var inOrder = this.InOrdersServices.GetById(id);
            var viewModel = this.Mapper.Map<InOrderViewModel>(inOrder);
            
            return View(viewModel);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InOrderInputModel model)
        {
            // Bind date works only with browser datepicker
            model.StartDate = DateTime.Now;
            model.AuthorId = User.Identity.GetUserId();
            var newInOrder = this.Mapper.Map<InOrder>(model);
            this.InOrdersServices.Create(newInOrder);
            return this.RedirectToAction("Index");
        }

        //public ActionResult Edit(int id)
        //{
        //    var inOrder = this.InOrdersServices.GetById(id);
        //    var viewModel = this.Mapper.Map<>
        //}
    }
}