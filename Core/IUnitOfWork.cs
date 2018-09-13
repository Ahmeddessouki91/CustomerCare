using System.Threading.Tasks;

namespace CustomerCare.Core
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}