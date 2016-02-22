﻿namespace OrdersSystem.Web.ViewModels.OutOrders
{
    using System;
    using System.Collections.Generic;
    using Infrastructure.Mapping;
    using Models;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Common;
    public class OutOrderEditViewModel : IMapFrom<OutOrder>, IMapTo<OutOrder>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Description name must be between 3 and 2000 symbols")]
        [MaxLength(2000, ErrorMessage = "Description name must be between 3 and 2000 symbols")]
        [UIHint("TextArea")]
        public string Description { get; set; }

        [Display(Name = ValidationConstants.WorkerDisplayName)]
        public string WorkerId { get; set; }

        [Display(Name = ValidationConstants.SupplierDisplayName)]
        public int SupplierId { get; set; }

        [Display(Name = ValidationConstants.EndDateDisplayName)]
        public DateTime EndDate { get; set; }
        
        public OrderStatus Status { get; set; }

        public ICollection<SelectListItem> Workers { get; set; }        

        public ICollection<SelectListItem> Suppliers { get; set; }
    }
}