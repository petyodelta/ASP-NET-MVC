namespace OrdersSystem.Web.ViewModels.InOrders
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Models;
    using Common;
    public class InOrderEditViewModel : IMapFrom<InOrder>, IMapTo<InOrder>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Description name must be between 3 and 2000 symbols")]
        [MaxLength(2000, ErrorMessage = "Description name must be between 3 and 2000 symbols")]
        public string Description { get; set; }
        
        [Display(Name = ValidationConstants.WorkerDisplayName)]
        public string WorkerId { get; set; }

        [Display(Name = ValidationConstants.DiviceDisplayName)]
        public int DeviceId { get; set; }

        [Display(Name = ValidationConstants.DeviceCountDisplayName)]
        [Range(1, int.MaxValue, ErrorMessage = "Device count must be greater than 0")]
        public int DeviceCount { get; set; }

        [Display(Name = ValidationConstants.CustomerDisplayName)]
        public int CustomerId { get; set; }

        [Display(Name = ValidationConstants.EndDateDisplayName)]
        public DateTime EndDate { get; set; }

        public OrderStatus Status { get; set; }

        public ICollection<SelectListItem> Devices { get; set; }

        public ICollection<SelectListItem> Workers { get; set; }

        public ICollection<SelectListItem> Customers { get; set; }
    }
}