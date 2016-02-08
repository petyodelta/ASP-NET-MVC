namespace OrdersSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Device
    {
        private ICollection<InOrder> inOrders;

        public Device()
        {
            this.inOrders = new HashSet<InOrder>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Device name must be between 3 and 150 symbols")]
        [MaxLength(150, ErrorMessage = "Device name must be between 3 and 150 symbols")]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<InOrder> InOrders
        {
            get { return this.inOrders; }
            set { this.inOrders = value; }
        }
    }
}