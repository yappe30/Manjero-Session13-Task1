using AutoMapper;
using EmployeeExample.DTO;
using EmployeeExample.Models;
using EmployeeExample.Repository;

namespace EmployeeExample.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IMapper _mapper;
        private IEmployeeRepo _employeeRepository;
        public EmployeeService(IMapper mapper, IEmployeeRepo employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository; 
        }

        public async Task<List<EmployeeDto>> GetEmployee()
        {
            var employees = await _employeeRepository.GetEmployee();
           var records = _mapper.Map<List<EmployeeDto>>(employees);

            return records;
        }
        public async Task<AddEmployeeDto> AddEmployee(AddEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
           await _employeeRepository.AddEmployee(employee);

            return employeeDto;
        }

        public async Task<EmployeeDto> DeleteEmployee(int id) 
        {
           var result =  await _employeeRepository.DeleteEmployee(id);
            var record = _mapper.Map<EmployeeDto>(result);
            return record;
        }
        public async Task<AddEmployeeDto> UpdateEmployee(int id, AddEmployeeDto addEmployeeDto)
        {
            var result = await _employeeRepository.UpdateEmployee(id, addEmployeeDto);

            var record = _mapper.Map<AddEmployeeDto>(result);

            return record;
        }
    }
}
