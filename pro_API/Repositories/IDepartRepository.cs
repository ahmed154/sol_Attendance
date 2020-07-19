using pro_Models.Models;
using pro_Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pro_API.Repositories
{
    public interface IDepartRepository
    {
        Task<IEnumerable<Depart>> Search(string name);
        Task<IEnumerable<Depart>> GetDeparts();
        Task<DepartViewModel> GetDepart(int departId);
        Task<DepartViewModel> AddDepart(DepartViewModel departViewModel);
        Task<Depart> UpdateDepart(Depart depart);
        Task<Depart> DeleteDepart(int departId);
        
        /////////////////////////////////////////////////////////// Other interface methods
        //Task<Depart> GetDepartByName(string name);
        Task<Depart> GetDepartByname(Depart depart);
    }
}
