using pro_Models.Models;
using pro_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro_Server.Services
{
    public interface IDeviceService
    {
        Task<IEnumerable<DeviceViewModel>> GetDevices();
        Task<DeviceViewModel> GetDevice(int id);
        Task<DeviceViewModel> UpdateDevice(int id, DeviceViewModel deviceViewModel);
        Task<DeviceViewModel> CreateDevice(DeviceViewModel deviceViewModel);
        Task<DeviceViewModel> DeleteDevice(int id);
    }
}
