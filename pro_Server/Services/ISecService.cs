using pro_Models.Models;
using pro_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro_Server.Services
{
    public interface ISecService
    {
        Task<IEnumerable<SecViewModel>> GetSecs();
        Task<SecViewModel> GetSec(int id);
        Task<SecViewModel> UpdateSec(int id, SecViewModel secViewModel);
        Task<SecViewModel> CreateSec(SecViewModel secViewModel);
        Task<SecViewModel> DeleteSec(int id);
    }
}
