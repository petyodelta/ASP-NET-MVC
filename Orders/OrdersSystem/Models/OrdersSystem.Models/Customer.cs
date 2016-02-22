namespace OrdersSystem.Models
{
    using Common;
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
        [MinLength(ValidationConstants.NameMinLength, ErrorMessage = ValidationConstants.CustomerNameErrorMessage)]
        [MaxLength(ValidationConstants.NameMaxLength, ErrorMessage = ValidationConstants.CustomerNameErrorMessage)]
        public string Name { get; set; }
        // TODO : Extract consts
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
