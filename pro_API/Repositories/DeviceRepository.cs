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
    public class DeviceRepository : IDeviceRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;

        public DeviceRepository(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }
        async Task<IEnumerable<DeviceViewModel>> IDeviceRepository.Search(string name)
        {
            List<DeviceViewModel> deviceViewModels = new List<DeviceViewModel>();

            IQueryable<Device> query = appDbContext.Devices;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }

            var devices = await query.ToListAsync();

            foreach (var device in devices)
            {
                deviceViewModels.Add(new DeviceViewModel { Device = device });
            }
            return deviceViewModels;
        }
        public async Task<IEnumerable<DeviceViewModel>> GetDevices()
        {
            List<DeviceViewModel> deviceViewModels = new List<DeviceViewModel>();
            var devices = await appDbContext.Devices.ToListAsync();
            foreach (var device in devices)
            {
                deviceViewModels.Add(new DeviceViewModel { Device = device});
            }
            return deviceViewModels; 
        }
        public async Task<DeviceViewModel> GetDevice(int deviceId)
        {
            DeviceViewModel deviceViewModel = new DeviceViewModel();
            deviceViewModel.Device = await appDbContext.Devices.FirstOrDefaultAsync(e => e.Id == deviceId);
            return deviceViewModel;
        }
        public async Task<DeviceViewModel> AddDevice(DeviceViewModel deviceViewModel)
        {
            var result = await appDbContext.Devices.AddAsync(deviceViewModel.Device);
            await appDbContext.SaveChangesAsync();

            deviceViewModel.Device = result.Entity;
            return deviceViewModel;
        }
        public async Task<DeviceViewModel> UpdateDevice(DeviceViewModel deviceViewModel)
        {
            Device result = await appDbContext.Devices
                .FirstOrDefaultAsync(e => e.Id == deviceViewModel.Device.Id);

            if (result != null)
            {
                //result.Name = deviceViewModel.Device.Name;
                //result.Number = deviceViewModel.Device.Number;
                //result.Ip = deviceViewModel.Device.Ip;
                //result.Port = deviceViewModel.Device.Port;

                result = mapper.Map(deviceViewModel.Device, result);

                await appDbContext.SaveChangesAsync();
                return new DeviceViewModel { Device = result };
            }

            return null;
        }
        public async Task<DeviceViewModel> DeleteDevice(int deviceId)
        {
            var result = await appDbContext.Devices
                .FirstOrDefaultAsync(e => e.Id == deviceId);
            if (result != null)
            {
                appDbContext.Devices.Remove(result);
                await appDbContext.SaveChangesAsync();
                return new DeviceViewModel { Device = result };
            }

            return null;
        }
/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
        public async Task<Device> GetDeviceByname(Device device)
        {
            return await appDbContext.Devices.Where(n => n.Name == device.Name && n.Id != device.Id)
                .FirstOrDefaultAsync();
        }
        public async Task<List<DropDowenIntModel>> GetForDropDowenList()
        {
            var dropDowenIntModel = await appDbContext.Devices.Select(x => new DropDowenIntModel { Id = x.Id, Name = x.Name }).ToListAsync();
            return dropDowenIntModel;
        }
    }
}
