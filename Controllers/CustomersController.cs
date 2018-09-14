using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using CustomerCare.Controllers.Resources;
using CustomerCare.Controllers.Resources.CustomerResources;
using CustomerCare.Core;
using CustomerCare.Core.Models;
using System;

namespace CustomerCare.Controllers
{
    [Route("/api/[Controller]")]
    public class CustomersController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICustomerRepository customerRepo;
        private readonly IUnitOfWork uow;
        public CustomersController(IMapper mapper, ICustomerRepository customerRepo, IUnitOfWork uow)
        {
            this.uow = uow;
            this.customerRepo = customerRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<QueryResult<CustomerResource>> GetCustomers(CustomerQueryResource filterResource)
        {
            var filter = mapper.Map<CustomerQueryResource, CustomerQuery>(filterResource);

            var queryResult = await customerRepo.GetCustomers(filter);

            return mapper.Map<QueryResult<Customer>, QueryResult<CustomerResource>>(queryResult);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await customerRepo.GetCustomer(id);
            if (customer == null)
                return NotFound();

            var customerResource = mapper.Map<Customer, CustomerResource>(customer);

            return Ok(customerResource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerSaveResource customerResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var customer = mapper.Map<CustomerSaveResource, Customer>(customerResource);

            customerRepo.Add(customer);
            await uow.CompleteAsync();

            await customerRepo.GetCustomer(customer.Id);

            var result = mapper.Map<Customer, CustomerResource>(customer);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] CustomerSaveResource customerResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customer = await customerRepo.GetCustomer(id);

            if (customer == null)
                return NotFound();


            mapper.Map<CustomerSaveResource, Customer>(customerResource, customer);

            await uow.CompleteAsync();

            customer = await customerRepo.GetCustomer(customer.Id);
            var result = mapper.Map<Customer, CustomerResource>(customer);
            return Ok(result);
        }
    }
}