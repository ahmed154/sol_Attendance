using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pro_API.Repositories;
using pro_Models.Models;
using pro_Models.ViewModels;

namespace pro_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<EmployeeViewModel>>> Search(string name)
        {
            try
            {
                var result = await employeeRepository.Search(name);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await employeeRepository.GetEmployees());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmployeeViewModel>> GetEmployee(int id)
        {
            try
            {
                var result = await employeeRepository.GetEmployee(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<EmployeeViewModel>> CreateEmployee(EmployeeViewModel employeeViewModel)
        {
            try
            {
                if (employeeViewModel == null)return BadRequest();
                employeeViewModel.Employee.WorksysId = 1;

                // Add custom model validation error
                Employee dep = await employeeRepository.GetEmployeeByname(employeeViewModel.Employee);
                if (dep != null)
                {
                    ModelState.AddModelError("Name", $"Employee name: {employeeViewModel.Employee.Name} already in use");
                    return BadRequest(ModelState);
                }

                employeeViewModel = await employeeRepository.AddEmployee(employeeViewModel);

                return CreatedAtAction(nameof(GetEmployee),
                    new { id = employeeViewModel.Employee.Id }, employeeViewModel);
            }
            catch (DbUpdateException Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Ex.InnerException.Message);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<EmployeeViewModel>> UpdateEmployee(int id, EmployeeViewModel employeeViewModel)
        {
            try
            {
                if (id != employeeViewModel.Employee.Id)
                    return BadRequest("Employee ID mismatch");

                var employeeToUpdate = await employeeRepository.GetEmployee(id);

                if (employeeToUpdate == null)
                    return NotFound($"Employee with Id = {id} not found");

                // Add custom model validation error
                Employee dep = await employeeRepository.GetEmployeeByname(employeeViewModel.Employee);
                if (dep != null)
                {
                    ModelState.AddModelError("Name", $"Employee name: {employeeViewModel.Employee.Name} already in use");
                    return BadRequest(ModelState);
                }

                return await employeeRepository.UpdateEmployee(employeeViewModel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EmployeeViewModel>> DeleteEmployee(int id)
        {
            try
            {
                var employeeToDelete = await employeeRepository.GetEmployee(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return await employeeRepository.DeleteEmployee(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
