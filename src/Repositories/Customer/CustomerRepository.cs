using dotnetautomapper.Data;
using dotnetautomapper.Interfaces.Customer;
using dotnetautomapper.Models.Customer;

namespace dotnetautomapper.Repositories.Customer.Customer;

public class CustomerRepository : BaseRepository<CustomerBaseModel>, ICustomerRepository
{
    public readonly BaseDbContext _context;
    public CustomerRepository(BaseDbContext context) : base(context)
    {
        _context = context;
    }
}