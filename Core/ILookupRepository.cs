using System.Threading.Tasks;
using CustomerCare.Controllers.Resources;
using CustomerCare.Core.Models;

namespace CustomerCare.Core
{
    public interface ILookupRepository
    {
        Task<QueryResult<Country>> GetCountries(CountryQuery queryObj);
        Task<QueryResult<Job>> GetJobs(JobQuery queryObj);
    }
}