using System.Threading.Tasks;
using AutoMapper;
using CustomerCare.Controllers.Resources;
using CustomerCare.Core;
using CustomerCare.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerCare.Controllers
{
    [Route("/api/[Controller]")]
    public class CountriesController : Controller
    {
        private readonly IMapper mapper;
        private readonly ILookupRepository repository;

        public CountriesController(IMapper mapper, ILookupRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<QueryResult<CountryResource>> GetCountries(CountryQuery filterResource)
        {
            var queryResult = await repository.GetCountries(filterResource);
            return mapper.Map<QueryResult<Country>, QueryResult<CountryResource>>(queryResult);
        }
    }
}