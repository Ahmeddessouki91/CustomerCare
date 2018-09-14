using System.Threading.Tasks;
using AutoMapper;
using CustomerCare.Controllers.Resources;
using CustomerCare.Core;
using CustomerCare.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerCare.Controllers
{
    [Route("/api/[Controller]")]
    public class JobsController : Controller
    {
        private readonly ILookupRepository repository;
        private readonly IMapper mapper;
        public JobsController(ILookupRepository repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<QueryResult<KeyValuePairResource>> GetJobs(JobQuery filterResource)
        {
            var queryResult = await repository.GetJobs(filterResource);
            return mapper.Map<QueryResult<Job>, QueryResult<KeyValuePairResource>>(queryResult);
        }

    }
}