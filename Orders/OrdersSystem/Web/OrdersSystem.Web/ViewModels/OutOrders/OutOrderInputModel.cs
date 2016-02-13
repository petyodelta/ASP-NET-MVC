namespace OrdersSystem.Web.ViewModels.OutOrders
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Models;
    using System.ComponentModel.DataAnnotations;

    public class OutOrderInputModel : IMapTo<OutOrder>
    {
        [Required]
        [MinLength(3, ErrorMessage = "Description name must be between 3 and 2000 symbols")]
        [MaxLength(2000, ErrorMessage = "Description name must be between 3 and 2000 symbols")]
        public string Description { get; set; }

        public string AuthorId { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime StartDate { get; set; }

        public OrderStatus Status { get; set; }

        public int SupplierId { get; set; }

        public ICollection<SelectListItem> Suppliers { get; set; }

        public ICollection<SelectListItem> Authors { get; set; }
    }
}