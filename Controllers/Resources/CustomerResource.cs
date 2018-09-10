using System.ComponentModel.DataAnnotations;

namespace CustomerCare.Controllers.Resources
{
    public class CustomerResource
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string Mobile { get; set; }
        public bool Activated { get; set; }
    }
}