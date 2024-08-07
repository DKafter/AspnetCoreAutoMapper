using System.Reflection;
using dotnetautomapper.Models.Customer;
using Microsoft.EntityFrameworkCore;

namespace dotnetautomapper.Data;

public class BaseDbContext : DbContext
{
    public DbSet<CustomerBaseModel> Customers { get; set; }
    public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
    {
        Customers = Set<CustomerBaseModel>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}