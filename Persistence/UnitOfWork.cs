using System.Threading.Tasks;
using CustomerCare.Core;

namespace CustomerCare.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CuCareDbContext _context;

        public async Task CompleteAsyn()
        {
            await _context.SaveChangesAsync();
        }
        public UnitOfWork(CuCareDbContext context)
        {
            this._context = context;
        }
    }
}