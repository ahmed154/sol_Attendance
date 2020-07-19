using pro_Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pro_API.Repositories
{
    public interface IDepartRepository
    {
        Task<IEnumerable<Depart>> Search(string name);
        Task<IEnumerable<Depart>> GetDeparts();
        Task<Depart> GetDepart(int departId);
        Task<Depart> AddDepart(Depart depart);
        Task<Depart> UpdateDepart(Depart depart);
        Task<Depart> DeleteDepart(int departId);
        
        /////////////////////////////////////////////////////////// Other interface methods
        //Task<Depart> GetDepartByName(string name);
        Task<Depart> GetDepartByname(Depart depart);
    }
}
