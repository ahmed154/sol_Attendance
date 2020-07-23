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
    public class WorksysController : ControllerBase
    {
        private readonly IWorksysRepository worksysRepository;

        public WorksysController(IWorksysRepository worksysRepository)
        {
            this.worksysRepository = worksysRepository;
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<WorksysViewModel>>> Search(string name)
        {
            try
            {
                var result = await worksysRepository.Search(name);

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
        public async Task<ActionResult> GetWorksyss()
        {
            try
            {
                return Ok(await worksysRepository.GetWorksyss());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<WorksysViewModel>> GetWorksys(int id)
        {
            try
            {
                var result = await worksysRepository.GetWorksys(id);

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
        public async Task<ActionResult<WorksysViewModel>> CreateWorksys(WorksysViewModel worksysViewModel)
        {
            try
            {
                if (worksysViewModel == null)return BadRequest();

                // Add custom model validation error
                Worksys dep = await worksysRepository.GetWorksysByname(worksysViewModel.Worksys);
                if (dep != null)
                {
                    ModelState.AddModelError("Name", $"Worksys name: {worksysViewModel.Worksys.Name} already in use");
                    return BadRequest(ModelState);
                }

                worksysViewModel = await worksysRepository.AddWorksys(worksysViewModel);

                return CreatedAtAction(nameof(GetWorksys),
                    new { id = worksysViewModel.Worksys.Id }, worksysViewModel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new worksys record");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<WorksysViewModel>> UpdateWorksys(int id, WorksysViewModel worksysViewModel)
        {
            try
            {
                if (id != worksysViewModel.Worksys.Id)
                    return BadRequest("Worksys ID mismatch");

                var worksysToUpdate = await worksysRepository.GetWorksys(id);

                if (worksysToUpdate == null)
                    return NotFound($"Worksys with Id = {id} not found");

                // Add custom model validation error
                Worksys dep = await worksysRepository.GetWorksysByname(worksysViewModel.Worksys);
                if (dep != null)
                {
                    ModelState.AddModelError("Name", $"Worksys name: {worksysViewModel.Worksys.Name} already in use");
                    return BadRequest(ModelState);
                }

                return await worksysRepository.UpdateWorksys(worksysViewModel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<WorksysViewModel>> DeleteWorksys(int id)
        {
            try
            {
                var worksysToDelete = await worksysRepository.GetWorksys(id);

                if (worksysToDelete == null)
                {
                    return NotFound($"Worksys with Id = {id} not found");
                }

                return await worksysRepository.DeleteWorksys(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
