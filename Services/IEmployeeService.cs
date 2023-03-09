using EmployeeExample.DTO;

namespace EmployeeExample.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetEmployee();

        Task<AddEmployeeDto> AddEmployee(AddEmployeeDto employeeDto);

        Task<EmployeeDto> DeleteEmployee(int id);

        Task<AddEmployeeDto> UpdateEmployee(int id, AddEmployeeDto addEmployeeDto);
    }
}