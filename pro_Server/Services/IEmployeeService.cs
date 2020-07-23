using pro_Models.Models;
using pro_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro_Server.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeViewModel>> GetEmployees();
        Task<EmployeeViewModel> GetEmployee(int id);
        Task<EmployeeViewModel> UpdateEmployee(int id, EmployeeViewModel employeeViewModel);
        Task<EmployeeViewModel> CreateEmployee(EmployeeViewModel employeeViewModel);
        Task<EmployeeViewModel> DeleteEmployee(int id);
    }
}
