namespace OrdersSystem.Web.Areas.Admin.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using Common;
    using Models;
    using Infrastructure.Mapping;
    
    public class CategoryInputModel : IMapTo<Category>
    {
        [Required]
        [MinLength(ValidationConstants.NameMinLength, ErrorMessage = ValidationConstants.CategoryNameErrorMessage)]
        [MaxLength(ValidationConstants.NameMaxLength, ErrorMessage = ValidationConstants.CategoryNameErrorMessage)]
        public string Name { get; set; }
    }
}