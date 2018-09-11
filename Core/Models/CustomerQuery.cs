using CustomerCare.Extensions;

namespace CustomerCare.Core.Models
{
    public class CustomerQuery : IQueryObject
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}