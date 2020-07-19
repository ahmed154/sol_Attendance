using Microsoft.EntityFrameworkCore;
using pro_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pro_API.Repositories;
using pro_Models.Models;

namespace pro_API.Repositories
{
    public class EmpRepository : IEmpRepository
    {
        private readonly AppDbContext appDbContext;

        public EmpRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        async Task<IEnumerable<Emp>> IEmpRepository.Search(string name)
        {
            IQueryable<Emp> query = appDbContext.Emps;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }

            return await query.ToListAsync();
        }
        public async Task<IEnumerable<Emp>> GetEmps()
        {
            return await appDbContext.Emps.ToListAsync();
        }

        public async Task<Emp> GetEmp(int empId)
        {
            return await appDbContext.Emps
                .FirstOrDefaultAsync(e => e.Id == empId);
        }

        public async Task<Emp> AddEmp(Emp emp)
        {
            var result = await appDbContext.Emps.AddAsync(emp);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Emp> UpdateEmp(Emp emp)
        {
            var result = await appDbContext.Emps
                .FirstOrDefaultAsync(e => e.Id == emp.Id);

            if (result != null)
            {
                result.Name = emp.Name;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Emp> DeleteEmp(int empId)
        {
            var result = await appDbContext.Emps
                .FirstOrDefaultAsync(e => e.Id == empId);
            if (result != null)
            {
                appDbContext.Emps.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Emp> GetEmpByName(string name)
        {
            Emp mod = await appDbContext.Emps.FirstOrDefaultAsync(e => e.Name == name);
            return mod;
        }
    }
}
