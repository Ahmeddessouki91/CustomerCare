using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerCare.Core.Models;

namespace CustomerCare.Core
{
    public interface IUserRepository
    {
        Task<QueryResult<User>> GetUsers(UserQuery queryObj);
        Task<User> GetUser(int id, bool includeRelated = true);
    }
}