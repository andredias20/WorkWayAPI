using Microsoft.EntityFrameworkCore;
using Models;

public class WorkWayContext : DbContext
{
    public WorkWayContext(DbContextOptions<WorkWayContext> opts)
        : base(opts)
    {
        
    }

    public DbSet<Person> People {get; set;}
}
