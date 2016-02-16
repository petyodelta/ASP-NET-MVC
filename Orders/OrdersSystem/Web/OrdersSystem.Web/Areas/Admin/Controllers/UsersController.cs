namespace OrdersSystem.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using Infrastructure.Mapping;
    using Ninject;
    using Services.Contracts;
    using System.Web.Mvc;
    using ViewModels;
    using Web.Controllers;

    public class UsersController : BaseController
    {
        [Inject]
        public IUsersServices UsersServices { get; set; }

        [Inject]
        public IRolesServices RolesServices { get; set; }

        public ActionResult Index()
        {
            var users = this.UsersServices.GetAll().To<UserViewModel>();

            return View(users);
        }

        public ActionResult Edit(string id)
        {
            var user = this.UsersServices.GetById(id);
            var viewModel = this.Mapper.Map<UserEditModel>(user);

            //viewModel.Roles = this.RolesServices.All()
            //    .Select(x => new SelectListItem()
            //    {
            //        Text = x.Name,
            //        Value = x.Id.ToString()
            //    })
            //    .ToList();

            return this.View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserEditModel model)
        {
            if (ModelState.IsValid)
            {
                this.UsersServices.Update(model.Id, model.Email);
                TempData["Success"] = "User email updated successfully.";
                return this.RedirectToAction("Index");
            }

            return this.View("Edit", model);
        }
    }
}