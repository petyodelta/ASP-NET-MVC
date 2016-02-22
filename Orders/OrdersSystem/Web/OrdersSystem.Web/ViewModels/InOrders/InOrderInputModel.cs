namespace OrdersSystem.Web.ViewModels.InOrders
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Models;
    using System.ComponentModel.DataAnnotations;
    using Common;
    public class InOrderInputModel : IMapTo<InOrder>
    {
        [Required]
        [MinLength(3, ErrorMessage = ValidationConstants.DescriptionErrorMessage)]
        [MaxLength(2000, ErrorMessage = ValidationConstants.DescriptionErrorMessage)]
        [UIHint("TextArea")]
        public string Description { get; set; }

        public string AuthorId { get; set; }

        [Display(Name = ValidationConstants.WorkerDisplayName)]
        public string WorkerId { get; set; }

        [Display(Name = ValidationConstants.DiviceDisplayName)]
        public int DeviceId { get; set; }

        [Required]
        [Display(Name = ValidationConstants.DeviceCountDisplayName)]
        [Range(1, int.MaxValue, ErrorMessage = ValidationConstants.DeviceCountErrorMessage)]
        public int DeviceCount { get; set; }

        [Display(Name = ValidationConstants.CustomerDisplayName)]
        public int CustomerId { get; set; }
        
        [Display(Name = ValidationConstants.EndDateDisplayName)]
        public DateTime EndDate { get; set; }

        public DateTime StartDate { get; set; }

        public OrderStatus Status { get; set; }

        public bool IsRepair { get; set; }

        public ICollection<SelectListItem> Devices { get; set; }

        public ICollection<SelectListItem> Authors { get; set; }

        public ICollection<SelectListItem> Workers { get; set; }
        
        public ICollection<SelectListItem> Customers { get; set; }
    }
}