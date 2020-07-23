using pro_Models.Models;
using pro_Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pro_API.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeViewModel>> Search(string name);
        Task<IEnumerable<EmployeeViewModel>> GetEmployees();
        Task<EmployeeViewModel> GetEmployee(int employeeId);
        Task<EmployeeViewModel> AddEmployee(EmployeeViewModel employeeViewModel);
        Task<EmployeeViewModel> UpdateEmployee(EmployeeViewModel employee);
        Task<EmployeeViewModel> DeleteEmployee(int employeeId);
        
        /////////////////////////////////////////////////////////// Other interface methods
        //Task<Employee> GetEmployeeByName(string name);
        Task<Employee> GetEmployeeByname(Employee employee);
    }
}
