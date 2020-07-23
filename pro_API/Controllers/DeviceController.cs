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
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceRepository deviceRepository;

        public DeviceController(IDeviceRepository deviceRepository)
        {
            this.deviceRepository = deviceRepository;
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<DeviceViewModel>>> Search(string name)
        {
            try
            {
                var result = await deviceRepository.Search(name);

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
        public async Task<ActionResult> GetDevices()
        {
            try
            {
                return Ok(await deviceRepository.GetDevices());
            }
            catch (DbUpdateException Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Ex.InnerException.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DeviceViewModel>> GetDevice(int id)
        {
            try
            {
                var result = await deviceRepository.GetDevice(id);

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
        public async Task<ActionResult<DeviceViewModel>> CreateDevice(DeviceViewModel deviceViewModel)
        {
            try
            {
                if (deviceViewModel == null)return BadRequest();

                // Add custom model validation error
                Device dep = await deviceRepository.GetDeviceByname(deviceViewModel.Device);
                if (dep != null)
                {
                    ModelState.AddModelError("Name", $"Device name: {deviceViewModel.Device.Name} already in use");
                    return BadRequest(ModelState);
                }

                deviceViewModel = await deviceRepository.AddDevice(deviceViewModel);

                return CreatedAtAction(nameof(GetDevice),
                    new { id = deviceViewModel.Device.Id }, deviceViewModel);
            }
            catch (DbUpdateException Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Ex.InnerException.Message);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<DeviceViewModel>> UpdateDevice(int id, DeviceViewModel deviceViewModel)
        {
            try
            {
                if (id != deviceViewModel.Device.Id)
                    return BadRequest("Device ID mismatch");

                var deviceToUpdate = await deviceRepository.GetDevice(id);

                if (deviceToUpdate == null)
                    return NotFound($"Device with Id = {id} not found");

                // Add custom model validation error
                Device dep = await deviceRepository.GetDeviceByname(deviceViewModel.Device);
                if (dep != null)
                {
                    ModelState.AddModelError("Name", $"Device name: {deviceViewModel.Device.Name} already in use");
                    return BadRequest(ModelState);
                }

                return await deviceRepository.UpdateDevice(deviceViewModel);
            }
            catch (DbUpdateException Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Ex.InnerException.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<DeviceViewModel>> DeleteDevice(int id)
        {
            try
            {
                var deviceToDelete = await deviceRepository.GetDevice(id);

                if (deviceToDelete == null)
                {
                    return NotFound($"Device with Id = {id} not found");
                }

                return await deviceRepository.DeleteDevice(id);
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
                return Ok(await deviceRepository.GetForDropDowenList());
            }
            catch (DbUpdateException Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Ex.InnerException.Message);
            }
        }
    }
}
