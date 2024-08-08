using dotnetautomapper.Dtos.Customer;
using MediatR;

namespace dotnetautomapper.Commands.Customer;

public sealed record RemoveExistingCustomerCommand(int id): IRequest<CustomerReadDto>;