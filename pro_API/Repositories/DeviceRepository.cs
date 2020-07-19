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
    public class DeviceRepository : IDeviceRepository
    {
        private readonly AppDbContext appDbContext;

        public DeviceRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        async Task<IEnumerable<Device>> IDeviceRepository.Search(string name)
        {
            IQueryable<Device> query = appDbContext.Devices;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }

            return await query.ToListAsync();
        }
        public async Task<IEnumerable<Device>> GetDevices()
        {
            return await appDbContext.Devices.ToListAsync();
        }

        public async Task<Device> GetDevice(int deviceId)
        {
            return await appDbContext.Devices
                .FirstOrDefaultAsync(e => e.Id == deviceId);
        }

        public async Task<Device> AddDevice(Device device)
        {
            var result = await appDbContext.Devices.AddAsync(device);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Device> UpdateDevice(Device device)
        {
            var result = await appDbContext.Devices
                .FirstOrDefaultAsync(e => e.Id == device.Id);

            if (result != null)
            {
                result.Name = device.Name;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Device> DeleteDevice(int deviceId)
        {
            var result = await appDbContext.Devices
                .FirstOrDefaultAsync(e => e.Id == deviceId);
            if (result != null)
            {
                appDbContext.Devices.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Device> GetDeviceByName(string name)
        {
            Device mod = await appDbContext.Devices.FirstOrDefaultAsync(e => e.Name == name);
            return mod;
        }
    }
}
