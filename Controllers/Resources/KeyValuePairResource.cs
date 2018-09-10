using System.ComponentModel.DataAnnotations;

namespace CustomerCare.Controllers.Resources
{
    public class KeyValuePairResource
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}