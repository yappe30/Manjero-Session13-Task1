
using AutoMapper;
using EmployeeExample.DTO;
using EmployeeExample.Models;

namespace EmployeeExample.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile() 
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<AddEmployeeDto, Employee>();
            CreateMap<Employee, AddEmployeeDto>();
        }
    }
}
