using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pro_API.Repositories;
using pro_Models.Models;


namespace pro_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IEmpRepository empRepository;

        public EmpController(IEmpRepository empRepository)
        {
            this.empRepository = empRepository;
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Emp>>> Search(string name)
        {
            try
            {
                var result = await empRepository.Search(name);

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
        public async Task<ActionResult> GetEmps()
        {
            try
            {
                return Ok(await empRepository.GetEmps());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Emp>> GetEmp(int id)
        {
            try
            {
                var result = await empRepository.GetEmp(id);

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
        public async Task<ActionResult<Emp>> CreateEmp(Emp emp)
        {
            try
            {
                if (emp == null)
                    return BadRequest();

                // Add custom model validation error
                Emp dep = await empRepository.GetEmpByName(emp.Name);

                if (dep != null)
                {
                    ModelState.AddModelError("name", "Emp name already in use");
                    return BadRequest(ModelState);
                }

                var createdEmp = await empRepository.AddEmp(emp);

                return CreatedAtAction(nameof(GetEmp),
                    new { id = createdEmp.Id }, createdEmp);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new emp record");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Emp>> UpdateEmp(int id, Emp emp)
        {
            try
            {
                if (id != emp.Id)
                    return BadRequest("Emp ID mismatch");

                var empToUpdate = await empRepository.GetEmp(id);

                if (empToUpdate == null)
                    return NotFound($"Emp with Id = {id} not found");

                return await empRepository.UpdateEmp(emp);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Emp>> DeleteEmp(int id)
        {
            try
            {
                var empToDelete = await empRepository.GetEmp(id);

                if (empToDelete == null)
                {
                    return NotFound($"Emp with Id = {id} not found");
                }

                return await empRepository.DeleteEmp(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
