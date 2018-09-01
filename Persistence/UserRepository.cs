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
    public class UserRepository : IUserRepository
    {
        private readonly CuCareDbContext context;
        public UserRepository(CuCareDbContext context)
        {
            this.context = context;
        }
        public async Task<QueryResult<User>> GetUsers(UserQuery queryObj)
        {
            var result = new QueryResult<User>();
            var query = context.Users.Where(u =>
                        string.IsNullOrEmpty(queryObj.Name) || u.Name.Contains(queryObj.Name)).AsQueryable();

            var columnsMap = new Dictionary<string, Expression<Func<User, object>>>
            {
                ["Name"] = u => u.Name,
                ["Email"] = u => u.Email
            };
            query = query.ApplyOrdering(queryObj, columnsMap);

            result.TotalItems = await query.CountAsync();
            query = query.ApplyPaging(queryObj);
            result.Items = await query.ToListAsync();

            return result;
        }

        public async Task<User> GetUser(int id, bool includeRelated = true)
        {
             if (!includeRelated)
                return await context.Users.FindAsync(id);

            return await context.Users.Include(u => u.Customers)
                          .SingleOrDefaultAsync(v => v.Id == id);
        }
    }
}