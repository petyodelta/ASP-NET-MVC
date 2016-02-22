namespace OrdersSystem.Web.Areas.Admin.ViewModels.Suppliers
{
    using System.ComponentModel.DataAnnotations;

    using Infrastructure.Mapping;
    using Models;
    
    public class SupplierEditModel :IMapFrom<Supplier>, IMapTo<Supplier>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Supplier name must be between 3 and 150 symbols")]
        [MaxLength(150, ErrorMessage = "Supplier name must be between 3 and 150 symbols")]
        public string Name { get; set; }
    }
}