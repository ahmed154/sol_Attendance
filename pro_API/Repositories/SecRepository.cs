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
    public class SecRepository : ISecRepository
    {
        private readonly AppDbContext appDbContext;

        public SecRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        async Task<IEnumerable<Sec>> ISecRepository.Search(string name)
        {
            IQueryable<Sec> query = appDbContext.Secs;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }

            return await query.ToListAsync();
        }
        public async Task<IEnumerable<Sec>> GetSecs()
        {
            return await appDbContext.Secs.ToListAsync();
        }

        public async Task<Sec> GetSec(int secId)
        {
            return await appDbContext.Secs
                .FirstOrDefaultAsync(e => e.Id == secId);
        }

        public async Task<Sec> AddSec(Sec sec)
        {
            var result = await appDbContext.Secs.AddAsync(sec);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Sec> UpdateSec(Sec sec)
        {
            var result = await appDbContext.Secs
                .FirstOrDefaultAsync(e => e.Id == sec.Id);

            if (result != null)
            {
                result.Name = sec.Name;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Sec> DeleteSec(int secId)
        {
            var result = await appDbContext.Secs
                .FirstOrDefaultAsync(e => e.Id == secId);
            if (result != null)
            {
                appDbContext.Secs.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Sec> GetSecByName(string name)
        {
            Sec mod = await appDbContext.Secs.FirstOrDefaultAsync(e => e.Name == name);
            return mod;
        }
    }
}
