using dotnetautomapper.Dtos.Customer;
using MediatR;

namespace dotnetautomapper.Queries;

public record GetCustomerByIdQuery(int? id) : IRequest<CustomerReadDto>;