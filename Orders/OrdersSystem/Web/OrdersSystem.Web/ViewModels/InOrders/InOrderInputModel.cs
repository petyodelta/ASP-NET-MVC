namespace OrdersSystem.Web.ViewModels.InOrders
{   
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Models;

    public class InOrderInputModel : IMapTo<InOrder>
    {
        public string Description { get; set; }

        public string AuthorId { get; set; }

        public string WorkerId { get; set; }

        public int DeviceId { get; set; }

        public int DeviceCount { get; set; }

        public int CustomerId { get; set; }

        public DateTime EndDate { get; set; }

        public OrderStatus Status { get; set; }

        public bool IsRepair { get; set; }

        public ICollection<SelectListItem> Devices { get; set; }

        public ICollection<SelectListItem> Authors { get; set; }

        public ICollection<SelectListItem> Statuses { get; set; }

        public ICollection<SelectListItem> Customers { get; set; }
    }
}