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
    public class SecController : ControllerBase
    {
        private readonly ISecRepository secRepository;

        public SecController(ISecRepository secRepository)
        {
            this.secRepository = secRepository;
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Sec>>> Search(string name)
        {
            try
            {
                var result = await secRepository.Search(name);

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
        public async Task<ActionResult> GetSecs()
        {
            try
            {
                return Ok(await secRepository.GetSecs());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Sec>> GetSec(int id)
        {
            try
            {
                var result = await secRepository.GetSec(id);

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
        public async Task<ActionResult<Sec>> CreateSec(Sec sec)
        {
            try
            {
                if (sec == null)
                    return BadRequest();

                // Add custom model validation error
                Sec dep = await secRepository.GetSecByName(sec.Name);

                if (dep != null)
                {
                    ModelState.AddModelError("name", "Sec name already in use");
                    return BadRequest(ModelState);
                }

                var createdSec = await secRepository.AddSec(sec);

                return CreatedAtAction(nameof(GetSec),
                    new { id = createdSec.Id }, createdSec);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new sec record");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Sec>> UpdateSec(int id, Sec sec)
        {
            try
            {
                if (id != sec.Id)
                    return BadRequest("Sec ID mismatch");

                var secToUpdate = await secRepository.GetSec(id);

                if (secToUpdate == null)
                    return NotFound($"Sec with Id = {id} not found");

                return await secRepository.UpdateSec(sec);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Sec>> DeleteSec(int id)
        {
            try
            {
                var secToDelete = await secRepository.GetSec(id);

                if (secToDelete == null)
                {
                    return NotFound($"Sec with Id = {id} not found");
                }

                return await secRepository.DeleteSec(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
