using pro_Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace pro_Server.Services
{
    public interface IImportDataService
    {
        Task<IEnumerable<IO>> GetAll();
        Task ImportData(FileStream fileStream);
    }
}
