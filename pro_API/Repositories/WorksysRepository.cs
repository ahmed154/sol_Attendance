using Microsoft.EntityFrameworkCore;
using pro_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pro_API.Repositories;
using pro_Models.Models;
using pro_Models.ViewModels;
using AutoMapper;

namespace pro_API.Repositories
{
    public class WorksysRepository : IWorksysRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;

        public WorksysRepository(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }
        async Task<IEnumerable<WorksysViewModel>> IWorksysRepository.Search(string name)
        {
            List<WorksysViewModel> worksysViewModels = new List<WorksysViewModel>();

            IQueryable<Worksys> query = appDbContext.Worksyss;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }

            var worksyss = await query.ToListAsync();

            foreach (var worksys in worksyss)
            {
                worksysViewModels.Add(new WorksysViewModel { Worksys = worksys });
            }
            return worksysViewModels;
        }
        public async Task<IEnumerable<WorksysViewModel>> GetWorksyss()
        {
            List<WorksysViewModel> worksysViewModels = new List<WorksysViewModel>();
            var worksyss = await appDbContext.Worksyss.ToListAsync();
            foreach (var worksys in worksyss)
            {
                worksysViewModels.Add(new WorksysViewModel { Worksys = worksys});
            }
            return worksysViewModels; 
        }
        public async Task<WorksysViewModel> GetWorksys(int worksysId)
        {
            WorksysViewModel worksysViewModel = new WorksysViewModel();
            worksysViewModel.Worksys = await appDbContext.Worksyss.FirstOrDefaultAsync(e => e.Id == worksysId);
            return worksysViewModel;
        }
        public async Task<WorksysViewModel> AddWorksys(WorksysViewModel worksysViewModel)
        {
            var result = await appDbContext.Worksyss.AddAsync(worksysViewModel.Worksys);
            await appDbContext.SaveChangesAsync();

            worksysViewModel.Worksys = result.Entity;
            return worksysViewModel;
        }
        public async Task<WorksysViewModel> UpdateWorksys(WorksysViewModel worksysViewModel)
        {
            Worksys result = await appDbContext.Worksyss
                .FirstOrDefaultAsync(e => e.Id == worksysViewModel.Worksys.Id);

            if (result != null)
            {
                //result.Name = worksysViewModel.Worksys.Name;
                //result.Number = worksysViewModel.Worksys.Number;
                //result.Ip = worksysViewModel.Worksys.Ip;
                //result.Port = worksysViewModel.Worksys.Port;

                result = mapper.Map(worksysViewModel.Worksys, result);

                await appDbContext.SaveChangesAsync();
                return new WorksysViewModel { Worksys = result };
            }

            return null;
        }
        public async Task<WorksysViewModel> DeleteWorksys(int worksysId)
        {
            var result = await appDbContext.Worksyss
                .FirstOrDefaultAsync(e => e.Id == worksysId);
            if (result != null)
            {
                appDbContext.Worksyss.Remove(result);
                await appDbContext.SaveChangesAsync();
                return new WorksysViewModel { Worksys = result };
            }

            return null;
        }
/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
        public async Task<Worksys> GetWorksysByname(Worksys worksys)
        {
            return await appDbContext.Worksyss.Where(n => n.Name == worksys.Name && n.Id != worksys.Id)
                .FirstOrDefaultAsync();
        }
        public async Task<List<DropDowenIntModel>> GetWorksyssForDropDowenList()
        {
            var dropDowenIntModel = await appDbContext.Worksyss.Select(x => new DropDowenIntModel { Id = x.Id, Name = x.Name }).ToListAsync();
            return dropDowenIntModel;
        }
    }
}
