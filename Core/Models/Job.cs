using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCare.Core.Models
{
    [Table("Jobs")]

    public class Job
    {
        public int Id { get; set; }
        [Required]
        [StringLength(55)]
        public string Name { get; set; }
    }
}