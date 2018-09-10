using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using CustomerCare.Core.Models;

namespace CustomerCare.Controllers.Resources.UserResouce
{
    public class UserResource
    {
        public UserResource()
        {
            this.Interactions = new Collection<InteractionResource>();
            this.Customers = new Collection<CustomerResource>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool Deactive { get; set; }
        public int NumOfCustomers { get; set; }
        public int NumOfInteractions { get; set; }
        public ICollection<InteractionResource> Interactions { get; set; }
        public ICollection<CustomerResource> Customers { get; set; }
    }
}