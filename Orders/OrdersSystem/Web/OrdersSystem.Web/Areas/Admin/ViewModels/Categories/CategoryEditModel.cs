namespace OrdersSystem.Web.Areas.Admin.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using Infrastructure.Mapping;
    using Models;
    
    public class CategoryEditModel : IMapFrom<Category>, IMapTo<Category>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Category name must be between 3 and 150 symbols")]
        [MaxLength(150, ErrorMessage = "Category name must be between 3 and 150 symbols")]
        public string Name { get; set; }
    }
}