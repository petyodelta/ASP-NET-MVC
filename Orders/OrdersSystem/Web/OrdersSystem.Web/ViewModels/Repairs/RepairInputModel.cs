﻿namespace OrdersSystem.Web.ViewModels.Repairs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using OrdersSystem.Models;
    using OrdersSystem.Web.Infrastructure.Mapping;
    
    public class RepairInputModel : IMapTo<InOrder>
    {
        [Required]
        [MinLength(3, ErrorMessage = "Description name must be between 3 and 2000 symbols")]
        [MaxLength(2000, ErrorMessage = "Description name must be between 3 and 2000 symbols")]
        public string Description { get; set; }

        public string AuthorId { get; set; }

        public string WorkerId { get; set; }

        public int DeviceId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Device count must be greater than 0")]
        public int DeviceCount { get; set; }

        public int CustomerId { get; set; }

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