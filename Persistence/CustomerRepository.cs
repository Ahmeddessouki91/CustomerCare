using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CustomerCare.Core;
using CustomerCare.Core.Models;
using CustomerCare.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CustomerCare.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CuCareDbContext context;
        public CustomerRepository(CuCareDbContext context)
        {
            this.context = context;
        }

        public void Add(Customer customer)
        {
            context.Customers.Add(customer);
        }

        public async Task<Customer> GetCustomer(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Customers.FindAsync(id);

            return await context.Customers.Include(c => c.Interactions)
                                           .Include(c => c.User).SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<QueryResult<Customer>> GetCustomers(CustomerQuery queryObj)
        {
            var result = new QueryResult<Customer>();

            var query = context.Customers
                            .Where(c => (string.IsNullOrEmpty(queryObj.Name) || c.Name.StartsWith(queryObj.Name))
                                && (string.IsNullOrEmpty(queryObj.Mobile) || c.Name.StartsWith(queryObj.Mobile)))
                            .Include(c => c.Job)
                            .Include(c => c.User)
                            .AsQueryable();

            result.TotalItems = await query.CountAsync();
            result.Items = query.ApplyPaging(queryObj);

            return result;
        }

        public void Remove(Customer customer)
        {
            context.Customers.Remove(customer);
        }
    }
}