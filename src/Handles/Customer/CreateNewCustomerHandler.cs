﻿using AutoMapper;
using dotnetautomapper.Commands.Customer;
using dotnetautomapper.Dtos.Customer;
using dotnetautomapper.Interfaces.Customer;
using dotnetautomapper.Models.Customer;
using MediatR;

namespace dotnetautomapper.Handles;

public class CreateNewCustomerHandler : IRequestHandler<CreateNewCustomerCommand, CustomerReadDto>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CreateNewCustomerHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }
    public async Task<CustomerReadDto> Handle(CreateNewCustomerCommand request, CancellationToken cancellationToken)
    {
        var customerToInsert = _mapper.Map<CustomerBaseModel>(request.customer);
        await _customerRepository.AddAsync(customerToInsert);
        await _customerRepository.SaveAsync();
        var result  = _mapper.Map<CustomerReadDto>(customerToInsert);

        return result == null ? null : await Task.FromResult(result);
    }
}