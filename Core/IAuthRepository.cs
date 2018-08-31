using System.Threading.Tasks;
using CustomerCare.Core.Models;

namespace CustomerCare.Core
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string email, string password);
        Task<bool> UserExist(string email);
    }
}