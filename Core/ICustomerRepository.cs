using System.Threading.Tasks;
using CustomerCare.Core.Models;

namespace CustomerCare.Core
{
    public interface ICustomerRepository
    {
        Task<QueryResult<Customer>> GetCustomers(CustomerQuery queryObj);
        Task<Customer> GetCustomer(int id, bool includeRelated = true);
        void Add(Customer customer);
        void Remove(Customer customer);
    }
}