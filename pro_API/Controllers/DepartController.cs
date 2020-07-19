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
    public class DepartController : ControllerBase
    {
        private readonly IDepartRepository departRepository;

        public DepartController(IDepartRepository departRepository)
        {
            this.departRepository = departRepository;
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Depart>>> Search(string name)
        {
            try
            {
                var result = await departRepository.Search(name);

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
        public async Task<ActionResult> GetDeparts()
        {
            try
            {
                return Ok(await departRepository.GetDeparts());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Depart>> GetDepart(int id)
        {
            try
            {
                var result = await departRepository.GetDepart(id);

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
        public async Task<ActionResult<Depart>> CreateDepart(Depart depart)
        {
            try
            {
                if (depart == null)
                    return BadRequest();

                // Add custom model validation error
                Depart dep = await departRepository.GetDepartByname(depart);
                if (dep != null)
                {
                    ModelState.AddModelError("Name", $"Depart name: {depart.Name} already in use");
                    return BadRequest(ModelState);
                }

                var createdDepart = await departRepository.AddDepart(depart);

                return CreatedAtAction(nameof(GetDepart),
                    new { id = createdDepart.Id }, createdDepart);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new depart record");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Depart>> UpdateDepart(int id, Depart depart)
        {
            try
            {
                if (id != depart.Id)
                    return BadRequest("Depart ID mismatch");

                var departToUpdate = await departRepository.GetDepart(id);

                if (departToUpdate == null)
                    return NotFound($"Depart with Id = {id} not found");

                // Add custom model validation error
                Depart dep = await departRepository.GetDepartByname(depart);
                if (dep != null)
                {
                    ModelState.AddModelError("Name", $"Depart name: {depart.Name} already in use");
                    return BadRequest(ModelState);
                }

                return await departRepository.UpdateDepart(depart);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Depart>> DeleteDepart(int id)
        {
            try
            {
                var departToDelete = await departRepository.GetDepart(id);

                if (departToDelete == null)
                {
                    return NotFound($"Depart with Id = {id} not found");
                }

                return await departRepository.DeleteDepart(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
