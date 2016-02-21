namespace OrdersSystem.Web.Areas.Admin.ViewModels.Devices
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Models;

    public class DeviceEditModel : IMapFrom<Device>, IMapTo<Device>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Device name must be between 3 and 150 symbols")]
        [MaxLength(150, ErrorMessage = "Device name must be between 3 and 150 symbols")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public ICollection<SelectListItem> Categories { get; set; }
    }
}