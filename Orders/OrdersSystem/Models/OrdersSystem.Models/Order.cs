namespace OrdersSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Description name must be between 3 and 5000 symbols")]
        [MaxLength(5000, ErrorMessage = "Description name must be between 3 and 5000 symbols")]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public OrderStatus Status { get; set; }

        public int DeviceId { get; set; }

        [ForeignKey("DeviceId")]
        public virtual Device Device { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public string WorkerId { get; set; }

        [ForeignKey("WorkerId")]
        public virtual User Worker { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public  virtual User Author { get; set; }
    }
}