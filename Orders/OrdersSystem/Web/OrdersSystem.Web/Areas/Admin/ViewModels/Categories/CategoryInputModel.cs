namespace OrdersSystem.Web.Areas.Admin.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using Models;
    using Infrastructure.Mapping;

    public class CategoryInputModel : IMapTo<Category>
    {
        [Required]
        [MinLength(3, ErrorMessage = "Category name must be between 3 and 150 symbols")]
        [MaxLength(150, ErrorMessage = "Category name must be between 3 and 150 symbols")]
        public string Name { get; set; }
    }
}