using dotnetautomapper.Dtos.Customer;
using dotnetautomapper.Models.Customer;
using MediatR;

namespace dotnetautomapper.Commands.Customer;

public sealed record CreateNewCustomerCommand(CustomerCreateDto customer) : IRequest<CustomerReadDto>;