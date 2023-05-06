using AutoMapper;
using dbfirstapproch.DTOs;
using dbfirstapproch.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EmployeeDto, Employee>();
        //CreateMap<Employee, EmployeeDto>();
        // Add more mappings as needed
    }
}
