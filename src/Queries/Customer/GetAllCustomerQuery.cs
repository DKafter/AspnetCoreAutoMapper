using dotnetautomapper.Dtos.Customer;
using MediatR;

namespace dotnetautomapper.Queries;

public record GetAllCustomerQuery : IRequest<IList<CustomerReadDto>>;