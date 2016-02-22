namespace OrdersSystem.Web.Areas.Admin.ViewModels.Suppliers
{
    using System.ComponentModel.DataAnnotations;

    using Common;
    using Infrastructure.Mapping;
    using Models;
    
    public class SupplierEditModel :IMapFrom<Supplier>, IMapTo<Supplier>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = ValidationConstants.SupplierNameErrorMessage)]
        [MaxLength(150, ErrorMessage = ValidationConstants.SupplierNameErrorMessage)]
        public string Name { get; set; }
    }
}