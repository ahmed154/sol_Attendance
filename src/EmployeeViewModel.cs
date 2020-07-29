using pro_Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace pro_Models.ViewModels
{
    public class EmployeeViewModel
    {
        [ValidateComplexType]
        public Employee Employee { get; set; } = new Employee();
        public string Exception { get; set; }
    }
}
