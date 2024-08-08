using AutoMapper;
using dotnetautomapper.Dtos.Customer;
using dotnetautomapper.Interfaces.Customer;
using dotnetautomapper.Queries;
using MediatR;

namespace dotnetautomapper.Handles;

public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, IList<CustomerReadDto>>
{
    private readonly ICustomerRepository _customerRepository;
    private IMapper _mapper;

    public GetAllCustomerHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }
    
    
    public async Task<IList<CustomerReadDto>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
    {
        var customerList = await _customerRepository.GetAllAsync();
        return _mapper.Map<IList<CustomerReadDto>>(customerList);
    }
}