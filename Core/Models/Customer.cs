using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCare.Core.Models
{
    [Table("Customers")]
    public class Customer
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
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public int JobId { get; set; }
        public Job Job { get; set; }
        [Required]
        public int GovernerateId { get; set; }
        public Governerate Governerate { get; set; }

        public ICollection<Interaction> Interactions { get; set; }

        public Customer()
        {
            this.Interactions = new Collection<Interaction>();
        }
    }
}