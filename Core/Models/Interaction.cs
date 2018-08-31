using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCare.Core.Models
{
    [Table("Interactions")]
    public class Interaction
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        [Required]
        public int Status { get; set; }
    }
}