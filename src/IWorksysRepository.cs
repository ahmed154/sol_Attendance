using pro_Models.Models;
using pro_Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pro_API.Repositories
{
    public interface IWorksysRepository
    {
        Task<IEnumerable<WorksysViewModel>> Search(string name);
        Task<IEnumerable<WorksysViewModel>> GetWorksyss();
        Task<WorksysViewModel> GetWorksys(int worksysId);
        Task<WorksysViewModel> AddWorksys(WorksysViewModel worksysViewModel);
        Task<WorksysViewModel> UpdateWorksys(WorksysViewModel worksys);
        Task<WorksysViewModel> DeleteWorksys(int worksysId);
        
        /////////////////////////////////////////////////////////// Other interface methods
        //Task<Worksys> GetWorksysByName(string name);
        Task<Worksys> GetWorksysByname(Worksys worksys);
    }
}
