using AutoMapper;
using dotnetautomapper.Commands.Customer;
using dotnetautomapper.Dtos.Customer;
using dotnetautomapper.Interfaces.Customer;
using dotnetautomapper.Models.Customer;
using MediatR;

namespace dotnetautomapper.Handles;

public class UpdateCustomerHandler : IRequestHandler<EditExistingCustomerCommand, CustomerReadDto>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public UpdateCustomerHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }
    public Task<CustomerReadDto> Handle(EditExistingCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<CustomerBaseModel>(request.customerUpdate);
        _customerRepository.UpdateAsync(customer);
        _customerRepository.SaveAsync();
        var result = _mapper.Map<CustomerReadDto>(customer);
        return Task.FromResult(result);
    }
}