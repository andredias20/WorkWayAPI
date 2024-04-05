using Domain.Trips;
using Domain.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infraestruture.Context
{
    public class WorkWayContext : DbContext
    {
        
        public WorkWayContext(DbContextOptions<WorkWayContext> opts)
            : base(opts)
        {
        }
        public virtual DbSet<Person> Person {get; set;}
        public virtual DbSet<Trip> Trip { get; set; }
        
    }

    public class WorkWayDbContextFactory : IDesignTimeDbContextFactory<WorkWayContext>
    {
        public WorkWayContext CreateDbContext(string[] args)
        {
            var opts = new DbContextOptionsBuilder<WorkWayContext>();
            opts.UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=workway;");

            return new WorkWayContext(opts.Options);
        }
    }
}