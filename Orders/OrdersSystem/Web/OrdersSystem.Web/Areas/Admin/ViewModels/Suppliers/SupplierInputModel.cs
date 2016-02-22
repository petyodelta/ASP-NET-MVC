namespace OrdersSystem.Web.Areas.Admin.ViewModels.Suppliers
{
    using System.ComponentModel.DataAnnotations;

    using OrdersSystem.Models;
    using OrdersSystem.Web.Infrastructure.Mapping;
    
    public class SupplierInputModel : IMapTo<Supplier>
    {
        [Required]
        [MinLength(3, ErrorMessage = "Supplier name must be between 3 and 150 symbols")]
        [MaxLength(150, ErrorMessage = "Supplier name must be between 3 and 150 symbols")]
        public string Name { get; set; }
    }
}