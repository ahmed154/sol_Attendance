using Microsoft.EntityFrameworkCore;
using pro_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pro_API.Repositories;
using pro_Models.Models;
using pro_Models.ViewModels;

namespace pro_API.Repositories
{
    public class DepartRepository : IDepartRepository
    {
        private readonly AppDbContext appDbContext;

        public DepartRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        async Task<IEnumerable<Depart>> IDepartRepository.Search(string name)
        {
            IQueryable<Depart> query = appDbContext.Departs;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }

            return await query.ToListAsync();
        }
        public async Task<IEnumerable<Depart>> GetDeparts()
        {
            return await appDbContext.Departs.ToListAsync(); 
        }
        public async Task<DepartViewModel> GetDepart(int departId)
        {
            DepartViewModel departViewModel = new DepartViewModel();
            departViewModel.Depart = await appDbContext.Departs.FirstOrDefaultAsync(e => e.Id == departId);
            return departViewModel;
        }
        public async Task<DepartViewModel> AddDepart(DepartViewModel departViewModel)
        {
            var result = await appDbContext.Departs.AddAsync(departViewModel.Depart);
            await appDbContext.SaveChangesAsync();

            departViewModel.Depart = result.Entity;
            return departViewModel;
        }
        public async Task<Depart> UpdateDepart(Depart depart)
        {
            var result = await appDbContext.Departs
                .FirstOrDefaultAsync(e => e.Id == depart.Id);

            if (result != null)
            {
                result.Name = depart.Name;
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
        public async Task<Depart> DeleteDepart(int departId)
        {
            var result = await appDbContext.Departs
                .FirstOrDefaultAsync(e => e.Id == departId);
            if (result != null)
            {
                appDbContext.Departs.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        //public async Task<Depart> GetDepartByName(string name)
        //{
        //    Depart mod = await appDbContext.Departs.FirstOrDefaultAsync(e => e.Name == name);
        //    return mod;
        //}
        public async Task<Depart> GetDepartByname(Depart depart)
        {
            return await appDbContext.Departs.Where(n => n.Name == depart.Name && n.Id != depart.Id)
                .FirstOrDefaultAsync();
        }
    }
}
