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
    public class DepartService : IDepartService
    {
        private readonly HttpClient httpClient;
        private readonly IHttpService httpService;
        private string url = "api/depart";
        private JsonSerializerOptions defaultJsonSerializerOptions =>new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public DepartService(HttpClient httpClient, IHttpService httpService)
        {
            this.httpClient = httpClient;
            this.httpService = httpService;
        }
        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<T>(responseString, options);
        }
        async Task<IEnumerable<DepartViewModel>> IDepartService.GetDeparts()
        {
            List<DepartViewModel> departViewModels = new List<DepartViewModel>();
            var response = await httpService.Get<List<DepartViewModel>>(url);

            if (!response.Success)
            {
                departViewModels.Add(new DepartViewModel { Exception = await response.GetBody() });
            }
            else
            {     
                 departViewModels = response.Response;              
            }
            return departViewModels;
        }
        public async Task<IEnumerable<Depart>> GetDeparts()
        {
            var responseHTTP = await httpClient.GetAsync(url);

            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = await Deserialize<List<Depart>>(responseHTTP, defaultJsonSerializerOptions);
                return response;
            }
            else
            {
                throw new ApplicationException(await responseHTTP.Content.ReadAsStringAsync());
            }
        }


        public async Task<DepartViewModel> CreateDepart(DepartViewModel departViewModel)
        {
            var dataJson = System.Text.Json.JsonSerializer.Serialize(departViewModel);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var responseHTTP = await httpClient.PostAsync(url, stringContent);

            if (responseHTTP.IsSuccessStatusCode)
            {
                departViewModel = await Deserialize<DepartViewModel>(responseHTTP, defaultJsonSerializerOptions);
            }
            else
            {
                departViewModel.Exception = await responseHTTP.Content.ReadAsStringAsync();
            }
            return departViewModel;
        }
        public async Task<DepartViewModel> UpdateDepart(int id, DepartViewModel departViewModel)
        {
            var dataJson = System.Text.Json.JsonSerializer.Serialize(departViewModel);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var responseHTTP = await httpClient.PutAsync($"{url}/{id}", stringContent);

            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = await Deserialize<DepartViewModel>(responseHTTP, defaultJsonSerializerOptions);
                departViewModel = response;
            }
            else
            {
                departViewModel.Exception = await responseHTTP.Content.ReadAsStringAsync();
            }
            return departViewModel;
        }

        public async Task<DepartViewModel> DeleteDepart(int id)
        {
            DepartViewModel departViewModel = new DepartViewModel();

            var response = await httpService.Delete($"{url}/{id}");
            if (!response.Success)
            {
                departViewModel.Exception = await response.GetBody();
            }
            return departViewModel;
        }



        public async Task<DepartViewModel> GetDepart(int id)
        {
            DepartViewModel departViewModel = new DepartViewModel();
            var response = await httpService.Get<DepartViewModel>($"{url}/{id}");

            if (!response.Success)
            {
                departViewModel.Exception = await response.GetBody();
            }
            else
            {
                departViewModel.Depart = response.Response.Depart;
            }
            return departViewModel;
        }
    }
}
