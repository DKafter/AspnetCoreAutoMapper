using AutoMapper;
using dotnetautomapper.Dtos.Customer;
using dotnetautomapper.Interfaces.Customer;
using dotnetautomapper.Models.Customer;
using Microsoft.AspNetCore.Mvc;

namespace dotnetautomapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;
    public CustomerController(ICustomerRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var data = await _repository.GetAllAsync();
        var result = _mapper.Map<IEnumerable<CustomerReadDto>>(data);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CustomerCreateDto dto)
    {
        var data = _mapper.Map<CustomerBaseModel>(dto);
        await _repository.AddAsync(data);
        await _repository.SaveAsync();
        return CreatedAtAction("Get", new {id = data.Id}, data);
    }

    [HttpPut("id")]
    public async Task<IActionResult> PutAsync(int id, CustomerUpdateDto dto)
    {
        var data = await _repository.GetAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        _mapper.Map(dto, data);
        await _repository.UpdateAsync(data);
        await _repository.SaveAsync();
        return NoContent();
    }
    
    [HttpDelete("id")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        await _repository.SaveAsync();
        return NoContent();
    }
}