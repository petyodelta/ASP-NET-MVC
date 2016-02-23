namespace OrdersSystem.Web.Areas.Admin.ViewModels.Devices
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Models;
    using Common;
    public class DeviceInputModel : IMapTo<Device>
    {
        [Required]
        [MinLength(ValidationConstants.NameMinLength, ErrorMessage = ValidationConstants.DeviceNameErrorMessage)]
        [MaxLength(ValidationConstants.NameMaxLength, ErrorMessage = ValidationConstants.DeviceNameErrorMessage)]
        public string Name { get; set; }

        [Required]
        [Display(Name = ValidationConstants.CategoryDisplayName)]
        public int CategoryId { get; set; }

        public ICollection<SelectListItem> Categories { get; set; }
    }
}