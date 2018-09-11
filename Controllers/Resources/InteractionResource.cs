using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerCare.Controllers.Resources
{
    public class InteractionResource
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        [Required]
        public int Status { get; set; }

        public KeyValuePairResource Customer { get; set; }

    }
}