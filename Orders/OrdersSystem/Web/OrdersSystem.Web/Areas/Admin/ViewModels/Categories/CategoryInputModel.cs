namespace OrdersSystem.Web.Areas.Admin.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using Common;
    using Models;
    using Infrastructure.Mapping;
    
    public class CategoryInputModel : IMapTo<Category>
    {
        [Required]
        [MinLength(3, ErrorMessage = ValidationConstants.CategoryNameErrorMessage)]
        [MaxLength(150, ErrorMessage = ValidationConstants.CategoryNameErrorMessage)]
        public string Name { get; set; }
    }
}