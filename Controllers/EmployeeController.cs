using AutoMapper;
using EmployeeExample.DTO;
using EmployeeExample.Models;
using EmployeeExample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;
        ILogger _logger;
        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployee()
        {
            var employee = await _employeeService.GetEmployee();

            if (employee == null)
            {
                _logger.LogInformation("Failed GetEmployee Data");
                return BadRequest();
            }
            else
            {
                _logger.LogInformation("Success GetEmployee Data");
                return Ok(employee);
               

             }
               
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee(AddEmployeeDto c)
        {
            try
            {
                var employee = await _employeeService.AddEmployee(c);

                _logger.LogInformation("Success UpdateEmployee Data");

                return Ok(employee);
            }
            catch (Exception e)
            {
                _logger.LogInformation("Failed UpdateEmployee Data");

                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult<EmployeeDto>> DeleteEmployee(int id) 
        {
            try
            {
                var employee = await _employeeService.DeleteEmployee(id);
                _logger.LogInformation("Success DeleteEmployee Data");

                return Ok(employee);
            } catch (Exception e)
            {
                _logger.LogInformation("Failed DeleteEmployee Data");

                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<AddEmployeeDto>> UpdateEmployee(int id, AddEmployeeDto addEmployeeDto)
        {
            try
            {
                var employee = await _employeeService.UpdateEmployee(id, addEmployeeDto);
                _logger.LogInformation("Success UpdateEmployee Data");

                return Ok(employee);
            }
            catch (Exception e)
            {
                _logger.LogInformation("Failed UpdateEmployee Data");

                return BadRequest(e.Message);
            }
        }
    }
}
