namespace OrdersSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        private ICollection<Device> devices;

        public Category()
        {
            this.devices = new HashSet<Device>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Category name must be between 3 and 150 symbols")]
        [MaxLength(150, ErrorMessage = "Category name must be between 3 and 150 symbols")]
        public string Name { get; set; }

        public virtual ICollection<Device> Devices
        {
            get { return this.devices; }
            set { this.devices = value; }
        }

    }
}
