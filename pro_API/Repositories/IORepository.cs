using Microsoft.EntityFrameworkCore;
using pro_API.Data;
using pro_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro_API.Repositories
{
    public class IORepository : IIORepository
    {
        private readonly AppDbContext appDbContext;

        public IORepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<IO>> GetAll()
        {
            var IOs = await appDbContext.IOs.ToListAsync();
            return IOs;
        }
        public async Task AddRangeAsync(List<IO> iOs)
        {
            await appDbContext.IOs.AddRangeAsync(iOs);
            await appDbContext.SaveChangesAsync();
        }
    }
}
