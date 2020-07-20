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
    public class SecService : ISecService
    {
        private readonly HttpClient httpClient;
        private readonly IHttpService httpService;
        private string url = "api/sec";
        private JsonSerializerOptions defaultJsonSerializerOptions =>new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public SecService(HttpClient httpClient, IHttpService httpService)
        {
            this.httpClient = httpClient;
            this.httpService = httpService;
        }
        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<T>(responseString, options);
        }
        async Task<IEnumerable<SecViewModel>> ISecService.GetSecs()
        {
            List<SecViewModel> secViewModels = new List<SecViewModel>();
            var response = await httpService.Get<List<SecViewModel>>(url);

            if (!response.Success)
            {
                secViewModels.Add(new SecViewModel { Exception = await response.GetBody() });
            }
            else
            {     
                 secViewModels = response.Response;              
            }
            return secViewModels;
        }
        public async Task<IEnumerable<Sec>> GetSecs()
        {
            var responseHTTP = await httpClient.GetAsync(url);

            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = await Deserialize<List<Sec>>(responseHTTP, defaultJsonSerializerOptions);
                return response;
            }
            else
            {
                throw new ApplicationException(await responseHTTP.Content.ReadAsStringAsync());
            }
        }


        public async Task<SecViewModel> CreateSec(SecViewModel secViewModel)
        {
            var dataJson = System.Text.Json.JsonSerializer.Serialize(secViewModel);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var responseHTTP = await httpClient.PostAsync(url, stringContent);

            if (responseHTTP.IsSuccessStatusCode)
            {
                secViewModel = await Deserialize<SecViewModel>(responseHTTP, defaultJsonSerializerOptions);
            }
            else
            {
                secViewModel.Exception = await responseHTTP.Content.ReadAsStringAsync();
            }
            return secViewModel;
        }
        public async Task<SecViewModel> UpdateSec(int id, SecViewModel secViewModel)
        {
            var dataJson = System.Text.Json.JsonSerializer.Serialize(secViewModel);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var responseHTTP = await httpClient.PutAsync($"{url}/{id}", stringContent);

            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = await Deserialize<SecViewModel>(responseHTTP, defaultJsonSerializerOptions);
                secViewModel = response;
            }
            else
            {
                secViewModel.Exception = await responseHTTP.Content.ReadAsStringAsync();
            }
            return secViewModel;
        }

        public async Task<SecViewModel> DeleteSec(int id)
        {
            SecViewModel secViewModel = new SecViewModel();

            var response = await httpService.Delete($"{url}/{id}");
            if (!response.Success)
            {
                secViewModel.Exception = await response.GetBody();
            }
            return secViewModel;
        }



        public async Task<SecViewModel> GetSec(int id)
        {
            SecViewModel secViewModel = new SecViewModel();
            var response = await httpService.Get<SecViewModel>($"{url}/{id}");

            if (!response.Success)
            {
                secViewModel.Exception = await response.GetBody();
            }
            else
            {
                secViewModel.Sec = response.Response.Sec;
            }
            return secViewModel;
        }
    }
}
