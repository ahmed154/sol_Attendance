using pro_Models.Models;
using pro_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro_Server.Services
{
    public interface IDepartService
    {
        Task<IEnumerable<DepartViewModel>> GetDeparts();
        Task<DepartViewModel> GetDepart(int id);
        Task<DepartViewModel> UpdateDepart(int id, Depart updatedDepart);
        Task<DepartViewModel> CreateDepart(Depart createdDepart);
        Task<DepartViewModel> DeleteDepart(int id);
    }
}
