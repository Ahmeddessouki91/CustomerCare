using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CustomerCare.Controllers.Resources
{
    public class CountryResource : KeyValuePairResource
    {
        public CountryResource()
        {
            this.Governerates = new Collection<KeyValuePairResource>();
        }
        public ICollection<KeyValuePairResource> Governerates { get; set; }
    }
}