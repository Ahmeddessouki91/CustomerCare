using System.ComponentModel.DataAnnotations;

namespace CustomerCare.Controllers.Resources.CustomerResources
{
    public class CustomerResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int Interactions { get; set; }
        public KeyValuePairResource User { get; set; }
        public bool Activated { get; set; }
    }
}