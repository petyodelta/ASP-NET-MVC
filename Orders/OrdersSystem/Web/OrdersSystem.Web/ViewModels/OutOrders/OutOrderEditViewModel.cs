namespace OrdersSystem.Web.ViewModels.OutOrders
{
    using System;
    using System.Collections.Generic;
    using Infrastructure.Mapping;
    using Models;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class OutOrderEditViewModel : IMapFrom<OutOrder>, IMapTo<OutOrder>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Description name must be between 3 and 2000 symbols")]
        [MaxLength(2000, ErrorMessage = "Description name must be between 3 and 2000 symbols")]
        public string Description { get; set; }

        public string AuthorId { get; set; }

        public int DeviceId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Device count must be greater than 0")]
        public int DeviceCount { get; set; }

        public int SupplierId { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime StartDate { get; set; }

        public OrderStatus Status { get; set; }

        public ICollection<SelectListItem> Authors { get; set; }        

        public ICollection<SelectListItem> Suppliers { get; set; }
    }
}