using AutoMapper;
using dotnetautomapper.Dtos.Customer;
using dotnetautomapper.Models.Customer;

namespace dotnetautomapper.Profiles.Customer;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerBaseModel, CustomerReadDto>();
        CreateMap<CustomerCreateDto, CustomerBaseModel>()
            .ForMember(m => m.CreatedAt, o => o.MapFrom(s => DateTime.Now.Date));
        CreateMap<CustomerUpdateDto, CustomerBaseModel>();
    }
}