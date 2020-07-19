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
        async Task<IEnumerable<DepartViewModel>> IDepartRepository.Search(string name)
        {
            List<DepartViewModel> departViewModels = new List<DepartViewModel>();

            IQueryable<Depart> query = appDbContext.Departs;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }

            var departs = await query.ToListAsync();

            foreach (var depart in departs)
            {
                departViewModels.Add(new DepartViewModel { Depart = depart });
            }
            return departViewModels;
        }
        public async Task<IEnumerable<DepartViewModel>> GetDeparts()
        {
            List<DepartViewModel> departViewModels = new List<DepartViewModel>();
            var departs = await appDbContext.Departs.ToListAsync();
            foreach (var depart in departs)
            {
                departViewModels.Add(new DepartViewModel { Depart = depart});
            }
            return departViewModels; 
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
        public async Task<DepartViewModel> UpdateDepart(DepartViewModel departViewModel)
        {
            var result = await appDbContext.Departs
                .FirstOrDefaultAsync(e => e.Id == departViewModel.Depart.Id);

            if (result != null)
            {
                result.Name = departViewModel.Depart.Name;
                await appDbContext.SaveChangesAsync();
                return new DepartViewModel { Depart = result };
            }

            return null;
        }
        public async Task<DepartViewModel> DeleteDepart(int departId)
        {
            var result = await appDbContext.Departs
                .FirstOrDefaultAsync(e => e.Id == departId);
            if (result != null)
            {
                appDbContext.Departs.Remove(result);
                await appDbContext.SaveChangesAsync();
                return new DepartViewModel { Depart = result };
            }

            return null;
        }
/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
        public async Task<Depart> GetDepartByname(Depart depart)
        {
            return await appDbContext.Departs.Where(n => n.Name == depart.Name && n.Id != depart.Id)
                .FirstOrDefaultAsync();
        }
    }
}
