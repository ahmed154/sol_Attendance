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
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        private readonly IHttpService httpService;
        private string url = "api/employee";
        private JsonSerializerOptions defaultJsonSerializerOptions =>new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public EmployeeService(HttpClient httpClient, IHttpService httpService)
        {
            this.httpClient = httpClient;
            this.httpService = httpService;
        }
        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<T>(responseString, options);
        }
        async Task<IEnumerable<EmployeeViewModel>> IEmployeeService.GetEmployees()
        {
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
            var response = await httpService.Get<List<EmployeeViewModel>>(url);

            if (!response.Success)
            {
                employeeViewModels.Add(new EmployeeViewModel { Exception = await response.GetBody() });
            }
            else
            {     
                 employeeViewModels = response.Response;              
            }
            return employeeViewModels;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var responseHTTP = await httpClient.GetAsync(url);

            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = await Deserialize<List<Employee>>(responseHTTP, defaultJsonSerializerOptions);
                return response;
            }
            else
            {
                throw new ApplicationException(await responseHTTP.Content.ReadAsStringAsync());
            }
        }


        public async Task<EmployeeViewModel> CreateEmployee(EmployeeViewModel employeeViewModel)
        {
            var dataJson = System.Text.Json.JsonSerializer.Serialize(employeeViewModel);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var responseHTTP = await httpClient.PostAsync(url, stringContent);

            if (responseHTTP.IsSuccessStatusCode)
            {
                employeeViewModel = await Deserialize<EmployeeViewModel>(responseHTTP, defaultJsonSerializerOptions);
            }
            else
            {
                employeeViewModel.Exception = await responseHTTP.Content.ReadAsStringAsync();
            }
            return employeeViewModel;
        }
        public async Task<EmployeeViewModel> UpdateEmployee(int id, EmployeeViewModel employeeViewModel)
        {
            var dataJson = System.Text.Json.JsonSerializer.Serialize(employeeViewModel);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var responseHTTP = await httpClient.PutAsync($"{url}/{id}", stringContent);

            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = await Deserialize<EmployeeViewModel>(responseHTTP, defaultJsonSerializerOptions);
                employeeViewModel = response;
            }
            else
            {
                employeeViewModel.Exception = await responseHTTP.Content.ReadAsStringAsync();
            }
            return employeeViewModel;
        }

        public async Task<EmployeeViewModel> DeleteEmployee(int id)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();

            var response = await httpService.Delete($"{url}/{id}");
            if (!response.Success)
            {
                employeeViewModel.Exception = await response.GetBody();
            }
            return employeeViewModel;
        }



        public async Task<EmployeeViewModel> GetEmployee(int id)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            var response = await httpService.Get<EmployeeViewModel>($"{url}/{id}");

            if (!response.Success)
            {
                employeeViewModel.Exception = await response.GetBody();
            }
            else
            {
                employeeViewModel.Employee = response.Response.Employee;
            }
            return employeeViewModel;
        }
    }
}
