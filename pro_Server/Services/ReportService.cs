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
    public class ReportService : IReportService
    {
        private readonly HttpClient httpClient;
        private readonly IHttpService httpService;
        private string url = "api/report";
        private JsonSerializerOptions defaultJsonSerializerOptions =>new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public ReportService(HttpClient httpClient, IHttpService httpService)
        {
            this.httpClient = httpClient;
            this.httpService = httpService;
        }
        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<T>(responseString, options);
        }

        public async Task<ReportViewModel> GetReport(ReportViewModel reportViewModel)
        {
            var response = await httpService.Get<ReportViewModel>($"{url}");

            if (!response.Success)
            {
                reportViewModel.Exception = await response.GetBody();
            }
            else
            {
                reportViewModel = response.Response;
            }
            return reportViewModel;
        }
    }
}
