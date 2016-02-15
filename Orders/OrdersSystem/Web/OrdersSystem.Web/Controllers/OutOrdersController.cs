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
    public class OutOrdersController : BaseController
    {
        [Inject]
        public IOutOrdersServices OutOrdersServices { get; set; }

        [Inject]
        public IUsersServices UsersServices { get; set; }

        [Inject]
        public ISuppliersServices SuppliersServices { get; set; }

        public ActionResult Index()
        {
            var outOrders = this.OutOrdersServices
                .GetAll()
                .To<OutOrderViewModel>();

            return View(outOrders);
        }

        public ActionResult Details(int id)
        {
            var outOrder = this.OutOrdersServices.GetById(id);
            var viewModel = this.Mapper.Map<OutOrderViewModel>(outOrder);

            return this.View(viewModel);
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OutOrderInputModel model)
        {
            model.StartDate = DateTime.Now;
            model.AuthorId = User.Identity.GetUserId();
            var newOutOrder = this.Mapper.Map<OutOrder>(model);
            this.OutOrdersServices.Create(newOutOrder);

            return this.RedirectToAction("Index");
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OutOrderEditViewModel model)
        {
            var outOrder = this.Mapper.Map<OutOrder>(model);
            this.OutOrdersServices.Update(model.Id, outOrder);

            return this.RedirectToAction("Details", new { id = model.Id });
        }
    }
}