namespace OrdersSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Device
    {
        private ICollection<Order> orders;

        public Device()
        {
            this.orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Device name must be between 3 and 150 symbols")]
        [MaxLength(150, ErrorMessage = "Device name must be between 3 and 150 symbols")]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Order> Orders
        {
            get { return this.orders; }
            set { this.orders = value; }
        }
    }
}