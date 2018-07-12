using API.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
