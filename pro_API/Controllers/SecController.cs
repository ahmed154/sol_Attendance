using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pro_API.Repositories;
using pro_Models.Models;
using pro_Models.ViewModels;

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
        public async Task<ActionResult<IEnumerable<SecViewModel>>> Search(string name)
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
        public async Task<ActionResult<SecViewModel>> GetSec(int id)
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
        public async Task<ActionResult<SecViewModel>> CreateSec(SecViewModel secViewModel)
        {
            try
            {
                if (secViewModel == null)return BadRequest();

                // Add custom model validation error
                Sec dep = await secRepository.GetSecByname(secViewModel.Sec);
                if (dep != null)
                {
                    ModelState.AddModelError("Name", $"Sec name: {secViewModel.Sec.Name} already in use");
                    return BadRequest(ModelState);
                }

                secViewModel = await secRepository.AddSec(secViewModel);

                return CreatedAtAction(nameof(GetSec),
                    new { id = secViewModel.Sec.Id }, secViewModel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new sec record");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<SecViewModel>> UpdateSec(int id, SecViewModel secViewModel)
        {
            try
            {
                if (id != secViewModel.Sec.Id)
                    return BadRequest("Sec ID mismatch");

                var secToUpdate = await secRepository.GetSec(id);

                if (secToUpdate == null)
                    return NotFound($"Sec with Id = {id} not found");

                // Add custom model validation error
                Sec dep = await secRepository.GetSecByname(secViewModel.Sec);
                if (dep != null)
                {
                    ModelState.AddModelError("Name", $"Sec name: {secViewModel.Sec.Name} already in use");
                    return BadRequest(ModelState);
                }

                return await secRepository.UpdateSec(secViewModel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<SecViewModel>> DeleteSec(int id)
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
