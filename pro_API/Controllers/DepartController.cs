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
    public class DepartController : ControllerBase
    {
        private readonly IDepartRepository departRepository;

        public DepartController(IDepartRepository departRepository)
        {
            this.departRepository = departRepository;
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<DepartViewModel>>> Search(string name)
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
            catch (DbUpdateException Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Ex.InnerException.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetDeparts()
        {
            try
            {
                return Ok(await departRepository.GetDeparts());
            }
            catch (DbUpdateException Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Ex.InnerException.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DepartViewModel>> GetDepart(int id)
        {
            try
            {
                var result = await departRepository.GetDepart(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (DbUpdateException Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Ex.InnerException.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<DepartViewModel>> CreateDepart(DepartViewModel departViewModel)
        {
            try
            {
                if (departViewModel == null)return BadRequest();

                // Add custom model validation error
                Depart dep = await departRepository.GetDepartByname(departViewModel.Depart);
                if (dep != null)
                {
                    ModelState.AddModelError("Name", $"Depart name: {departViewModel.Depart.Name} already in use");
                    return BadRequest(ModelState);
                }

                departViewModel = await departRepository.AddDepart(departViewModel);

                return CreatedAtAction(nameof(GetDepart),
                    new { id = departViewModel.Depart.Id }, departViewModel);
            }
            catch (DbUpdateException Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Ex.InnerException.Message);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<DepartViewModel>> UpdateDepart(int id, DepartViewModel departViewModel)
        {
            try
            {
                if (id != departViewModel.Depart.Id)
                    return BadRequest("Depart ID mismatch");

                var departToUpdate = await departRepository.GetDepart(id);

                if (departToUpdate == null)
                    return NotFound($"Depart with Id = {id} not found");

                // Add custom model validation error
                Depart dep = await departRepository.GetDepartByname(departViewModel.Depart);
                if (dep != null)
                {
                    ModelState.AddModelError("Name", $"Depart name: {departViewModel.Depart.Name} already in use");
                    return BadRequest(ModelState);
                }

                return await departRepository.UpdateDepart(departViewModel);
            }
            catch (DbUpdateException Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Ex.InnerException.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<DepartViewModel>> DeleteDepart(int id)
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
            catch (DbUpdateException Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Ex.InnerException.Message);
            }
        }
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>
        [HttpGet("drop")]
        public async Task<ActionResult> GetForDrop()
        {
            try
            {
                return Ok(await departRepository.GetForDropDowenList());
            }
            catch (DbUpdateException Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Ex.InnerException.Message);
            }
        }
    }
}
