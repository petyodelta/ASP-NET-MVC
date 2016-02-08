using System.ComponentModel.DataAnnotations;

namespace OrdersSystem.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(150)]
        public string Name { get; set; }
    }
}