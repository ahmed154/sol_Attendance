using System;
using BlazorServerApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using pro_Server.Auth;
using pro_Server.Handlers;
using pro_Server.Helpers;
using pro_Server.Models;
using pro_Server.Services;
using Syncfusion.Blazor;

namespace pro_Server
{
    public class Startup
    {
        //string uri = "https://localhost:44305/";
        string uri = "http://ahmed154-001-site4.etempurl.com/";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddTransient<ValidateHeaderHandler>();
            //services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddAuthorizationCore();
            services.AddScoped<JWTAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider, JWTAuthenticationStateProvider>(
                provider => provider.GetRequiredService<JWTAuthenticationStateProvider>()
            );
            services.AddScoped<ILoginService, JWTAuthenticationStateProvider>(
               provider => provider.GetRequiredService<JWTAuthenticationStateProvider>()
                );


            services.AddSyncfusionBlazor();

            services.AddHttpClient<IHttpService, HttpService>(client =>
            {
                client.BaseAddress = new Uri(uri);
            });
            services.AddHttpClient<IUserService, UserService>(client =>
            {
                client.BaseAddress = new Uri(uri);
            });
            services.AddHttpClient<IWeatherForecastService<WeatherForecast>, WeatherForecastService<WeatherForecast>>(client =>
            {
                client.BaseAddress = new Uri(uri);
            }).AddHttpMessageHandler<ValidateHeaderHandler>();

            services.AddHttpClient<IDepartService, DepartService>(client =>
            {
                client.BaseAddress = new Uri(uri);
            });
            services.AddHttpClient<ISecService, SecService>(client =>
            {
                client.BaseAddress = new Uri(uri);
            });
            services.AddHttpClient<IDeviceService, DeviceService>(client =>
            {
                client.BaseAddress = new Uri(uri);
            });
            services.AddHttpClient<IWorksysService, WorksysService>(client =>
            {
                client.BaseAddress = new Uri(uri);
            });
            services.AddHttpClient<IEmployeeService, EmployeeService>(client =>
            {
                client.BaseAddress = new Uri(uri);
            });
            services.AddScoped<IImportDataService, ImportDataService>();
            services.AddHttpClient<IReportService, ReportService>(client =>
            {
                client.BaseAddress = new Uri(uri);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjg4NjM0QDMxMzgyZTMyMmUzMFFkUlhXNkZkb09INjVTbDl6TTNZb2ZVTytiYU51UnF6OU9mZlFxdmpsMkk9;Mjg4NjM1QDMxMzgyZTMyMmUzMGZOVEwxd1FWREFDekV6TStydEN2d2JOUFFDNlFZeTRUcTFjR1FSVFRieW89");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
