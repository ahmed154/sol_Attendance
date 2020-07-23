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
    public class SecRepository : ISecRepository
    {
        private readonly AppDbContext appDbContext;

        public SecRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        async Task<IEnumerable<SecViewModel>> ISecRepository.Search(string name)
        {
            List<SecViewModel> secViewModels = new List<SecViewModel>();

            IQueryable<Sec> query = appDbContext.Secs;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }

            var secs = await query.ToListAsync();

            foreach (var sec in secs)
            {
                secViewModels.Add(new SecViewModel { Sec = sec });
            }
            return secViewModels;
        }
        public async Task<IEnumerable<SecViewModel>> GetSecs()
        {
            List<SecViewModel> secViewModels = new List<SecViewModel>();
            var secs = await appDbContext.Secs.ToListAsync();
            foreach (var sec in secs)
            {
                secViewModels.Add(new SecViewModel { Sec = sec});
            }
            return secViewModels; 
        }
        public async Task<SecViewModel> GetSec(int secId)
        {
            SecViewModel secViewModel = new SecViewModel();
            secViewModel.Sec = await appDbContext.Secs.FirstOrDefaultAsync(e => e.Id == secId);
            return secViewModel;
        }
        public async Task<SecViewModel> AddSec(SecViewModel secViewModel)
        {
            var result = await appDbContext.Secs.AddAsync(secViewModel.Sec);
            await appDbContext.SaveChangesAsync();

            secViewModel.Sec = result.Entity;
            return secViewModel;
        }
        public async Task<SecViewModel> UpdateSec(SecViewModel secViewModel)
        {
            var result = await appDbContext.Secs
                .FirstOrDefaultAsync(e => e.Id == secViewModel.Sec.Id);

            if (result != null)
            {
                result.Name = secViewModel.Sec.Name;
                await appDbContext.SaveChangesAsync();
                return new SecViewModel { Sec = result };
            }

            return null;
        }
        public async Task<SecViewModel> DeleteSec(int secId)
        {
            var result = await appDbContext.Secs
                .FirstOrDefaultAsync(e => e.Id == secId);
            if (result != null)
            {
                appDbContext.Secs.Remove(result);
                await appDbContext.SaveChangesAsync();
                return new SecViewModel { Sec = result };
            }

            return null;
        }
/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
        public async Task<Sec> GetSecByname(Sec sec)
        {
            return await appDbContext.Secs.Where(n => n.Name == sec.Name && n.Id != sec.Id)
                .FirstOrDefaultAsync();
        }
        public async Task<List<DropDowenIntModel>> GetForDropDowenList()
        {
            var dropDowenIntModel = await appDbContext.Secs.Select(x => new DropDowenIntModel { Id = x.Id, Name = x.Name }).ToListAsync();
            return dropDowenIntModel;
        }
    }
}
