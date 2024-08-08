using AutoMapper;
using dotnetautomapper.Commands.Customer;
using dotnetautomapper.Dtos.Customer;
using dotnetautomapper.Handles;
using dotnetautomapper.Interfaces.Customer;
using dotnetautomapper.Models.Customer;
using dotnetautomapper.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace dotnetautomapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    /*private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;*/
    private readonly IMediator _mediator;
    /*public CustomerController(ICustomerRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }*/
    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        /*var data = await _repository.GetAllAsync();
        var result = _mapper.Map<IEnumerable<CustomerReadDto>>(data);*/
        var data = _mediator.Send(new GetAllCustomerQuery());
        var result = await data;
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CustomerCreateDto dto)
    {
        /*var data = _mapper.Map<CustomerBaseModel>(dto);
        await _repository.AddAsync(data);
        await _repository.SaveAsync();*/
        var data = _mediator.Send(new CreateNewCustomerCommand(dto));
        return CreatedAtAction("Get", new {id = data.Id}, data);
    }

    [HttpPut("id")]
    public async Task<IActionResult> PutAsync(int id, [FromBody]CustomerUpdateDto dto)
    {
        /*var data = await _repository.GetAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        _mapper.Map(dto, data);
        await _repository.UpdateAsync(data);
        await _repository.SaveAsync();*/
        if (id != dto.Id) return BadRequest();

        var data = await _mediator.Send(new EditExistingCustomerCommand(dto));
        return NoContent();
    }
    
    [HttpDelete("id")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        /*await _repository.DeleteAsync(id);
        await _repository.SaveAsync();*/
        var data = await _mediator.Send(new RemoveExistingCustomerCommand(id));
        return NoContent();
    }
}