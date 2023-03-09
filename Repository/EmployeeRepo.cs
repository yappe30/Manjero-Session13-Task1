using AutoMapper;
using EmployeeExample.DTO;
using EmployeeExample.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeExample.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private EmployeeContext _employeeContext;

        public EmployeeRepo(EmployeeContext context)
        {
            _employeeContext = context;
        }
        public async Task<List<Employee>> GetEmployee()
        {
            return await _employeeContext.Employees.ToListAsync();
        }

        public async Task AddEmployee(Employee employee) 
        {
            await _employeeContext.Employees.AddAsync(employee);
            await _employeeContext.SaveChangesAsync();
        }

        public async Task<Employee> DeleteEmployee(int id) 
        {
            var employeeData = await _employeeContext.Employees.SingleOrDefaultAsync(found => found.Id == id);
              _employeeContext.Employees.Remove(employeeData);
            await _employeeContext.SaveChangesAsync();

            return employeeData;
        }
        public async Task<Employee> UpdateEmployee(int id, AddEmployeeDto addEmployeeDto)
        {
            var _employeeData = await _employeeContext.Employees.SingleOrDefaultAsync(found => found.Id == id);
            _employeeData.name = addEmployeeDto.name;
            _employeeData.email = addEmployeeDto.email;
            _employeeData.password = addEmployeeDto.password;
            await _employeeContext.SaveChangesAsync();

            return _employeeData;

        }
    }
}
