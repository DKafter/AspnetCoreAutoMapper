using AutoMapper;
using dotnetautomapper.Commands.Customer;
using dotnetautomapper.Dtos.Customer;
using dotnetautomapper.Interfaces.Customer;
using MediatR;

namespace dotnetautomapper.Handles;

public class DeleteCustomerHandler : IRequestHandler<RemoveExistingCustomerCommand, CustomerReadDto>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public DeleteCustomerHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }
    
    public async Task<CustomerReadDto> Handle(RemoveExistingCustomerCommand request, CancellationToken cancellationToken)
    {
        await _customerRepository.DeleteAsync(request.id);
        await _customerRepository.SaveAsync();
        var result = _mapper.Map<CustomerReadDto>(await _customerRepository.GetAsync(request.id));
        return result == null ? null : await Task.FromResult(result);
    }
}