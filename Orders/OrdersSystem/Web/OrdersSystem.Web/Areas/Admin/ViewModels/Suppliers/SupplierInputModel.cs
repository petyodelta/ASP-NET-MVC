namespace OrdersSystem.Web.Areas.Admin.ViewModels.Suppliers
{
    using System.ComponentModel.DataAnnotations;

    using Common;
    using OrdersSystem.Models;
    using OrdersSystem.Web.Infrastructure.Mapping;
    
    public class SupplierInputModel : IMapTo<Supplier>
    {
        [Required]
        [MinLength(3, ErrorMessage = ValidationConstants.SupplierNameErrorMessage)]
        [MaxLength(150, ErrorMessage = ValidationConstants.SupplierNameErrorMessage)]
        public string Name { get; set; }
    }
}