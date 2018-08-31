using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCare.Core.Models
{
    [Table("Governerates")]
    public class Governerate
    {
        public int Id { get; set; }
        [Required]
        [StringLength(55)]
        public string Name { get; set; }
        public Country Country { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}