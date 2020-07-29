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
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository reportRepository;

        public ReportController(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ReportViewModel>> GetReport(ReportViewModel reportViewModel)
        {
            try
            {
                var result = await reportRepository.GetReport(reportViewModel);

                if (result == null) return NotFound();

                return result;
            }
            catch (DbUpdateException Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    Ex.InnerException.Message);
            }
        }
    }
}
