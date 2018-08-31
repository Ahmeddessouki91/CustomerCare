using CustomerCare.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerCare.Persistence
{
    public class CuCareDbContext : DbContext
    {
        public CuCareDbContext(DbContextOptions<CuCareDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Interaction> Interactions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Governerate> Governerates { get; set; }
    }
}