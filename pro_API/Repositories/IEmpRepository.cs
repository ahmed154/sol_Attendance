using pro_Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pro_API.Repositories
{
    public interface IEmpRepository
    {
        Task<IEnumerable<Emp>> Search(string name);
        Task<IEnumerable<Emp>> GetEmps();
        Task<Emp> GetEmp(int empId);
        Task<Emp> AddEmp(Emp emp);
        Task<Emp> UpdateEmp(Emp emp);
        Task<Emp> DeleteEmp(int empId);
        
        /////////////////////////////////////////////////////////// Other interface methods
        Task<Emp> GetEmpByName(string name);
    }
}
