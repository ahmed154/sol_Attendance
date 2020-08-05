using pro_Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace pro_Models.ViewModels
{
    public class ReportGetViewModel
    {
        [ValidateComplexType]
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Worksys> Worksyss { get; set; } = new List<Worksys>();
        public List<Depart> Departs { get; set; } = new List<Depart>();
        public List<Sec> Secs { get; set; } = new List<Sec>();
        public DateTime FromDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
        public DateTime ToDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), 23, 59, 59);
        public AttReportSet AttReportSet { get; set; } = new AttReportSet();

        public string Exception { get; set; }
    }
}
