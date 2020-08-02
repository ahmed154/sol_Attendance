using Microsoft.EntityFrameworkCore;
using pro_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pro_API.Repositories;
using pro_Models.Models;
using pro_Models.ViewModels;
using AutoMapper;

namespace pro_API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;

        public EmployeeRepository(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }
        async Task<IEnumerable<EmployeeViewModel>> IEmployeeRepository.Search(string name)
        {
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();

            IQueryable<Employee> query = appDbContext.Employees;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }

            var employees = await query.ToListAsync();

            foreach (var employee in employees)
            {
                employeeViewModels.Add(new EmployeeViewModel { Employee = employee });
            }
            return employeeViewModels;
        }
        public async Task<IEnumerable<EmployeeViewModel>> GetEmployees()
        {
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
            var employees = await appDbContext.Employees.ToListAsync();
            foreach (var employee in employees)
            {
                employeeViewModels.Add(new EmployeeViewModel { Employee = employee});
            }
            return employeeViewModels; 
        }
        public async Task<EmployeeViewModel> GetEmployee(int employeeId)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.Employee = await appDbContext.Employees.FirstOrDefaultAsync(e => e.Id == employeeId);
            return employeeViewModel;
        }
        public async Task<EmployeeViewModel> AddEmployee(EmployeeViewModel employeeViewModel)
        {
            var result = await appDbContext.Employees.AddAsync(employeeViewModel.Employee);
            await appDbContext.SaveChangesAsync();

            employeeViewModel.Employee = result.Entity;
            return employeeViewModel;
        }
        public async Task<EmployeeViewModel> UpdateEmployee(EmployeeViewModel employeeViewModel)
        {
            Employee result = await appDbContext.Employees
                .FirstOrDefaultAsync(e => e.Id == employeeViewModel.Employee.Id);

            if (result != null)
            {
                //result.Name = employeeViewModel.Employee.Name;
                //result.Number = employeeViewModel.Employee.Number;
                //result.Ip = employeeViewModel.Employee.Ip;
                //result.Port = employeeViewModel.Employee.Port;

                result = mapper.Map(employeeViewModel.Employee, result);

                await appDbContext.SaveChangesAsync();
                return new EmployeeViewModel { Employee = result };
            }

            return null;
        }
        public async Task<EmployeeViewModel> DeleteEmployee(int employeeId)
        {
            var result = await appDbContext.Employees
                .FirstOrDefaultAsync(e => e.Id == employeeId);
            if (result != null)
            {
                appDbContext.Employees.Remove(result);
                await appDbContext.SaveChangesAsync();
                return new EmployeeViewModel { Employee = result };
            }

            return null;
        }
/// <summary>
/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
        public async Task<Employee> GetEmployeeByname(Employee employee)
        {
            return await appDbContext.Employees.Where(n => n.Name == employee.Name && n.Id != employee.Id)
                .FirstOrDefaultAsync();
        }
        public async Task<List<DropDowenIntModel>> GetForDropDowenList()
        {
            var dropDowenStringModel = await appDbContext.Employees.Select(x => new DropDowenIntModel { Id = x.Id, Name = x.Name }).ToListAsync();
            return dropDowenStringModel;
        }
    }
}
