namespace OrdersSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Supplier
    {
        private ICollection<OutOrder> outOrders;

        public Supplier()
        {
            this.outOrders = new HashSet<OutOrder>();
        }
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(150)]
        public string Name { get; set; }

        public virtual ICollection<OutOrder> OutOrders
        {
            get { return this.outOrders; }
            set { this.outOrders = value; }
        }

    }
}