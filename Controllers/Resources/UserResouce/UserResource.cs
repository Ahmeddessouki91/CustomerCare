using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using CustomerCare.Core.Models;

namespace CustomerCare.Controllers.Resources.UserResouce
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool Deactive { get; set; }
        public int NumOfInteractions { get; set; }
    }
}