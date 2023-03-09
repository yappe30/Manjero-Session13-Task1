using EmployeeExample.DTO;
using EmployeeExample.Models;

namespace EmployeeExample.Repository
{
    public interface IEmployeeRepo
    {
        Task<List<Employee>> GetEmployee();
        Task AddEmployee(Employee employee);

        Task<Employee> DeleteEmployee(int id);

        Task<Employee> UpdateEmployee(int id, AddEmployeeDto addEmployeeDto);
    }
}