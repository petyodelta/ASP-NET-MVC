namespace OrdersSystem.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Common;
    using Ninject;
    using Infrastructure.Mapping;
    using OrdersSystem.Services.Contracts;
    using ViewModels.Categories;
    using Web.Controllers;
    using Models;
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class CategoriesController : BaseController
    {
        [Inject]
        public ICategoriesServices CategoriesServices { get; set; }

        public ActionResult Index()
        {
            var viewModel = this.CategoriesServices.GetAll().To<CategoryViewModel>();
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CategoryInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                var categoryName = this.CategoriesServices
                    .GetAll()
                    .FirstOrDefault(x => x.Name.ToLower() == model.Name.ToLower());
                if (categoryName == null)
                {
                    var category = this.Mapper.Map<Category>(model);
                    this.CategoriesServices.Add(category);
                    TempData["Success"] = GlobalConstants.CategoryAddNotify;
                }
                else
                {
                    TempData["Warning"] = GlobalConstants.CategoryExistsNotify;
                }                

                return this.Redirect("/Admin/Categories/Index");
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var viewModel = this.CategoriesServices
                .GetAll()
                .Where(x => x.Id == id)
                .To<CategoryEditModel>()
                .FirstOrDefault();

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryEditModel model)
        {
            if (this.ModelState.IsValid)
            {
                var category = this.Mapper.Map<Category>(model);
                this.CategoriesServices.Update(model.Id, category);
                TempData["Success"] = GlobalConstants.CategoryUpdateNotify;

                return this.Redirect("/Admin/Categories/Index");
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            this.CategoriesServices.Delete(id);
            TempData["Success"] = GlobalConstants.CategoryDeletedNotify;
            return this.Redirect("/Admin/Categories/Index");
        }
    }
}