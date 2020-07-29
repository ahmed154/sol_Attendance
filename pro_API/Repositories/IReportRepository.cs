using pro_Models.Models;
using pro_Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pro_API.Repositories
{
    public interface IReportRepository
    {
        Task<ReportViewModel> GetReport(ReportViewModel reportViewModel);
    }
}
