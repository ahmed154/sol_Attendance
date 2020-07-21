using pro_Models.Models;
using pro_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro_Server.Services
{
    public interface IWorksysService
    {
        Task<IEnumerable<WorksysViewModel>> GetWorksyss();
        Task<WorksysViewModel> GetWorksys(int id);
        Task<WorksysViewModel> UpdateWorksys(int id, WorksysViewModel worksysViewModel);
        Task<WorksysViewModel> CreateWorksys(WorksysViewModel worksysViewModel);
        Task<WorksysViewModel> DeleteWorksys(int id);
    }
}
