using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CustomerCare.Controllers.Resources
{
    public class CountryResource
    {
        public CountryResource()
        {
            this.Governerates = new Collection<KeyValuePairResource>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<KeyValuePairResource> Governerates { get; set; }
    }
}