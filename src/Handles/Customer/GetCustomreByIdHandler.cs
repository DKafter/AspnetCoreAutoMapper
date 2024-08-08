using AutoMapper;
using dotnetautomapper.Dtos.Customer;
using dotnetautomapper.Interfaces.Customer;
using dotnetautomapper.Queries;
using MediatR;

namespace dotnetautomapper.Handles;

public class GetCustomreByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerReadDto>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetCustomreByIdHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }
    public async Task<CustomerReadDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetAsync(request.id);
        return _mapper.Map<CustomerReadDto>(customer);
    }
}