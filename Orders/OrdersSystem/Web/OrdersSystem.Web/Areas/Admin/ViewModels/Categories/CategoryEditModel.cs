namespace OrdersSystem.Web.Areas.Admin.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using Common;
    using Infrastructure.Mapping;
    using Models;
    
    public class CategoryEditModel : IMapFrom<Category>, IMapTo<Category>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = ValidationConstants.CategoryNameErrorMessage)]
        [MaxLength(150, ErrorMessage = ValidationConstants.CategoryNameErrorMessage)]
        public string Name { get; set; }
    }
}