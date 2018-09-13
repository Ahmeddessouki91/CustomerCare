using CustomerCare.Extensions;

namespace CustomerCare.Core.Models
{
    public class GovernrateQuery : IQueryObject
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}