namespace OrdersSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class InOrder : Order
    {       
        [Range(1, int.MaxValue, ErrorMessage = "Device count can not be less than 1")]
        public int DeviceCount { get; set; }

        public bool IsRepair { get; set; }

        public int DeviceId { get; set; }

        [ForeignKey("DeviceId")]
        public virtual Device Device { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public  virtual User Author { get; set; }
    }
}