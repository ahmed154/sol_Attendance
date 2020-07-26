using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pro_API.Repositories;
using pro_Models.Models;

namespace pro_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IOsController : ControllerBase
    {
        private readonly IIORepository iORepository;

        public IOsController(IIORepository iORepository)
        {
            this.iORepository = iORepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await iORepository.GetAll());
            }
            catch (DbUpdateException Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Ex.InnerException.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<IO>>> CreateIOs(List<IO> iOs)
        {
            try
            {
                if (iOs == null) return BadRequest();

                // Add custom model validation error
                if (iOs.Count == 0)
                {
                    ModelState.AddModelError("No Records", $"There's no records found on the file");
                    return BadRequest(ModelState);
                }

                await iORepository.AddRangeAsync(iOs);

                return new List<IO>();
            }
            catch (DbUpdateException Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Ex.InnerException.Message);
            }
        }
    }
}
