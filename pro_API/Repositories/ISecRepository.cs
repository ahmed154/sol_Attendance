using pro_Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pro_API.Repositories
{
    public interface ISecRepository
    {
        Task<IEnumerable<Sec>> Search(string name);
        Task<IEnumerable<Sec>> GetSecs();
        Task<Sec> GetSec(int secId);
        Task<Sec> AddSec(Sec sec);
        Task<Sec> UpdateSec(Sec sec);
        Task<Sec> DeleteSec(int secId);
        
        /////////////////////////////////////////////////////////// Other interface methods
        Task<Sec> GetSecByName(string name);
    }
}
