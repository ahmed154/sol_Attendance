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
    public class WorksysService : IWorksysService
    {
        private readonly HttpClient httpClient;
        private readonly IHttpService httpService;
        private string url = "api/worksys";
        private JsonSerializerOptions defaultJsonSerializerOptions =>new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public WorksysService(HttpClient httpClient, IHttpService httpService)
        {
            this.httpClient = httpClient;
            this.httpService = httpService;
        }
        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<T>(responseString, options);
        }
        async Task<IEnumerable<WorksysViewModel>> IWorksysService.GetWorksyss()
        {
            List<WorksysViewModel> worksysViewModels = new List<WorksysViewModel>();
            var response = await httpService.Get<List<WorksysViewModel>>(url);

            if (!response.Success)
            {
                worksysViewModels.Add(new WorksysViewModel { Exception = await response.GetBody() });
            }
            else
            {     
                 worksysViewModels = response.Response;              
            }
            return worksysViewModels;
        }
        public async Task<IEnumerable<Worksys>> GetWorksyss()
        {
            var responseHTTP = await httpClient.GetAsync(url);

            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = await Deserialize<List<Worksys>>(responseHTTP, defaultJsonSerializerOptions);
                return response;
            }
            else
            {
                throw new ApplicationException(await responseHTTP.Content.ReadAsStringAsync());
            }
        }


        public async Task<WorksysViewModel> CreateWorksys(WorksysViewModel worksysViewModel)
        {
            var dataJson = System.Text.Json.JsonSerializer.Serialize(worksysViewModel);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var responseHTTP = await httpClient.PostAsync(url, stringContent);

            if (responseHTTP.IsSuccessStatusCode)
            {
                worksysViewModel = await Deserialize<WorksysViewModel>(responseHTTP, defaultJsonSerializerOptions);
            }
            else
            {
                worksysViewModel.Exception = await responseHTTP.Content.ReadAsStringAsync();
            }
            return worksysViewModel;
        }
        public async Task<WorksysViewModel> UpdateWorksys(int id, WorksysViewModel worksysViewModel)
        {
            var dataJson = System.Text.Json.JsonSerializer.Serialize(worksysViewModel);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var responseHTTP = await httpClient.PutAsync($"{url}/{id}", stringContent);

            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = await Deserialize<WorksysViewModel>(responseHTTP, defaultJsonSerializerOptions);
                worksysViewModel = response;
            }
            else
            {
                worksysViewModel.Exception = await responseHTTP.Content.ReadAsStringAsync();
            }
            return worksysViewModel;
        }

        public async Task<WorksysViewModel> DeleteWorksys(int id)
        {
            WorksysViewModel worksysViewModel = new WorksysViewModel();

            var response = await httpService.Delete($"{url}/{id}");
            if (!response.Success)
            {
                worksysViewModel.Exception = await response.GetBody();
            }
            return worksysViewModel;
        }



        public async Task<WorksysViewModel> GetWorksys(int id)
        {
            WorksysViewModel worksysViewModel = new WorksysViewModel();
            var response = await httpService.Get<WorksysViewModel>($"{url}/{id}");

            if (!response.Success)
            {
                worksysViewModel.Exception = await response.GetBody();
            }
            else
            {
                worksysViewModel.Worksys = response.Response.Worksys;
            }
            return worksysViewModel;
        }
    }
}
