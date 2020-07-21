using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using pro_Models.Models;
using pro_Models.ViewModels;
using pro_Server.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace pro_Server.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly HttpClient httpClient;
        private readonly IHttpService httpService;
        private string url = "api/device";
        private JsonSerializerOptions defaultJsonSerializerOptions =>new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public DeviceService(HttpClient httpClient, IHttpService httpService)
        {
            this.httpClient = httpClient;
            this.httpService = httpService;
        }
        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<T>(responseString, options);
        }
        async Task<IEnumerable<DeviceViewModel>> IDeviceService.GetDevices()
        {
            List<DeviceViewModel> deviceViewModels = new List<DeviceViewModel>();
            var response = await httpService.Get<List<DeviceViewModel>>(url);

            if (!response.Success)
            {
                deviceViewModels.Add(new DeviceViewModel { Exception = await response.GetBody() });
            }
            else
            {     
                 deviceViewModels = response.Response;              
            }
            return deviceViewModels;
        }
        public async Task<IEnumerable<Device>> GetDevices()
        {
            var responseHTTP = await httpClient.GetAsync(url);

            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = await Deserialize<List<Device>>(responseHTTP, defaultJsonSerializerOptions);
                return response;
            }
            else
            {
                throw new ApplicationException(await responseHTTP.Content.ReadAsStringAsync());
            }
        }


        public async Task<DeviceViewModel> CreateDevice(DeviceViewModel deviceViewModel)
        {
            var dataJson = System.Text.Json.JsonSerializer.Serialize(deviceViewModel);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var responseHTTP = await httpClient.PostAsync(url, stringContent);

            if (responseHTTP.IsSuccessStatusCode)
            {
                deviceViewModel = await Deserialize<DeviceViewModel>(responseHTTP, defaultJsonSerializerOptions);
            }
            else
            {
                deviceViewModel.Exception = await responseHTTP.Content.ReadAsStringAsync();
            }
            return deviceViewModel;
        }
        public async Task<DeviceViewModel> UpdateDevice(int id, DeviceViewModel deviceViewModel)
        {
            var dataJson = System.Text.Json.JsonSerializer.Serialize(deviceViewModel);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var responseHTTP = await httpClient.PutAsync($"{url}/{id}", stringContent);

            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = await Deserialize<DeviceViewModel>(responseHTTP, defaultJsonSerializerOptions);
                deviceViewModel = response;
            }
            else
            {
                deviceViewModel.Exception = await responseHTTP.Content.ReadAsStringAsync();
            }
            return deviceViewModel;
        }

        public async Task<DeviceViewModel> DeleteDevice(int id)
        {
            DeviceViewModel deviceViewModel = new DeviceViewModel();

            var response = await httpService.Delete($"{url}/{id}");
            if (!response.Success)
            {
                deviceViewModel.Exception = await response.GetBody();
            }
            return deviceViewModel;
        }



        public async Task<DeviceViewModel> GetDevice(int id)
        {
            DeviceViewModel deviceViewModel = new DeviceViewModel();
            var response = await httpService.Get<DeviceViewModel>($"{url}/{id}");

            if (!response.Success)
            {
                deviceViewModel.Exception = await response.GetBody();
            }
            else
            {
                deviceViewModel.Device = response.Response.Device;
            }
            return deviceViewModel;
        }
    }
}
