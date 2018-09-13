using System.Linq;
using System.Threading.Tasks;
using CustomerCare.Controllers.Resources;
using CustomerCare.Core;
using CustomerCare.Core.Models;
using CustomerCare.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CustomerCare.Persistence
{
    public class LookupRepository : ILookupRepository
    {
        private readonly CuCareDbContext context;
        public LookupRepository(CuCareDbContext context)
        {
            this.context = context;

        }
        
        public async Task<QueryResult<Country>> GetCountries(CountryQuery queryObj)
        {
            var result = new QueryResult<Country>();

            var query = context.Countries.Include(c => c.Governerates).AsQueryable();

            result.TotalItems = await query.CountAsync();
            result.Items = query.ApplyPaging(queryObj);

            return result;
        }
        public async Task<QueryResult<Job>> GetJobs(JobQuery queryObj)
        {
            var result = new QueryResult<Job>();

            var query = context.Jobs.AsQueryable();

            result.TotalItems = await query.CountAsync();
            result.Items = query.ApplyPaging(queryObj);

            return result;
        }
    }
}