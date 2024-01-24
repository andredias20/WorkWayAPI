using Domain.Trips;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Infraestruture.Context
{
    public class WorkWayContext : DbContext
    {
        public WorkWayContext(DbContextOptions<WorkWayContext> opts)
            : base(opts)
        {}
        public DbSet<Person> Person {get; set;}
        public DbSet<Trip> Trip { get; set; }
        
    }
}