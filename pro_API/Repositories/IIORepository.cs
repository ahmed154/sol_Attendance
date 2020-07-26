using pro_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro_API.Repositories
{
    public interface IIORepository
    {
        Task AddRangeAsync(List<IO> iOs);
        Task<IEnumerable<IO>> GetAll();
    }
}
