namespace OrdersSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        private ICollection<InOrder> inOrders;

        public Customer()
        {
            this.inOrders = new HashSet<InOrder>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Customer name must be between 3 and 150 symbols")]
        [MaxLength(150, ErrorMessage = "Customer name must be between 3 and 150 symbols")]
        public string Name { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Address must be between 3 and 500 symbols")]
        [MaxLength(500, ErrorMessage = "Address must be between 3 and 500 symbols")]
        public string Address { get; set; }

        [MinLength(3, ErrorMessage = "Email must be between 3 and 150 symbols")]
        [MaxLength(150, ErrorMessage = "Email must be between 3 and 150 symbols")]
        public string Email { get; set; }

        [MinLength(3, ErrorMessage = "Telephone must be between 3 and 150 symbols")]
        [MaxLength(150, ErrorMessage = "Telephone must be between 3 and 150 symbols")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<InOrder> InOrders
        {
            get { return this.inOrders; }
            set { this.inOrders = value; }
        }
    }
}
