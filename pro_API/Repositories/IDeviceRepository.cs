using pro_Models.Models;
using pro_Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pro_API.Repositories
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<DeviceViewModel>> Search(string name);
        Task<IEnumerable<DeviceViewModel>> GetDevices();
        Task<DeviceViewModel> GetDevice(int deviceId);
        Task<DeviceViewModel> AddDevice(DeviceViewModel deviceViewModel);
        Task<DeviceViewModel> UpdateDevice(DeviceViewModel device);
        Task<DeviceViewModel> DeleteDevice(int deviceId);
        
        /////////////////////////////////////////////////////////// Other interface methods
        //Task<Device> GetDeviceByName(string name);
        Task<Device> GetDeviceByname(Device device);
    }
}
