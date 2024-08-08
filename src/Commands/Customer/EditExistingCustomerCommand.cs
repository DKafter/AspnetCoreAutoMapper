using dotnetautomapper.Dtos.Customer;
using MediatR;

namespace dotnetautomapper.Commands.Customer;

public sealed record EditExistingCustomerCommand(CustomerUpdateDto customerUpdate): IRequest<CustomerReadDto>;