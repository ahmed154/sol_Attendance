using pro_Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pro_API.Repositories
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> Search(string name);
        Task<IEnumerable<Device>> GetDevices();
        Task<Device> GetDevice(int deviceId);
        Task<Device> AddDevice(Device device);
        Task<Device> UpdateDevice(Device device);
        Task<Device> DeleteDevice(int deviceId);
        
        /////////////////////////////////////////////////////////// Other interface methods
        Task<Device> GetDeviceByName(string name);
    }
}
