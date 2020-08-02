using pro_Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace pro_Models.ViewModels
{
    public class ReportViewModel
    {
        [ValidateComplexType]
        public Employee Employee { get; set; } = new Employee();
        public Worksys Worksys { get; set; } = new Worksys();
        public DateTime FromDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
        public DateTime ToDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), 23, 59, 59);
        public List<IO> IOs { get; set; } = new List<IO>(); 

        public string Exception { get; set; }
    }
}
