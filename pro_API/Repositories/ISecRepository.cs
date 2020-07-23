using pro_Models.Models;
using pro_Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pro_API.Repositories
{
    public interface ISecRepository
    {
        Task<IEnumerable<SecViewModel>> Search(string name);
        Task<IEnumerable<SecViewModel>> GetSecs();
        Task<SecViewModel> GetSec(int secId);
        Task<SecViewModel> AddSec(SecViewModel secViewModel);
        Task<SecViewModel> UpdateSec(SecViewModel sec);
        Task<SecViewModel> DeleteSec(int secId);
        
        /////////////////////////////////////////////////////////// Other interface methods
        //Task<Sec> GetSecByName(string name);
        Task<Sec> GetSecByname(Sec sec);
        Task<List<DropDowenIntModel>> GetForDropDowenList();
    }
}
