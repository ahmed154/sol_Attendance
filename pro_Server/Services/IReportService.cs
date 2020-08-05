using pro_Models.Models;
using pro_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro_Server.Services
{
    public interface IReportService
    {
        Task<List<AttendanceReportViewModel>> GetAttendanceReport(ReportViewModel reportViewModel);
        Task<ReportViewModel> GetReportViewModel(ReportViewModel reportViewModel);
        Task<ReportGetViewModel> GetReportGetViewModel();
    }
}
