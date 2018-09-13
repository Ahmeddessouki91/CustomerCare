using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCare.Core.Models
{
    [Table("Countries")]

    public class Country
    {
        public Country()
        {
            this.Governerates = new Collection<Governerate>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(55)]
        public string Name { get; set; }

        public ICollection<Governerate> Governerates { get; set; }
    }
}