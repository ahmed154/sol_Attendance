using pro_Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace pro_Models.ViewModels
{
    public class ReportViewModel
    {
        public Employee Employee { get; set; } = new Employee();
        public DateTime FromDate { get; set; } = new DateTime(0001, 01, 01, 00, 00, 00);
        public DateTime ToDate { get; set; } = new DateTime(9999, 12, 31, 23, 59, 59);
        public List<IO> IOs { get; set; } = new List<IO>(); 

        public string Exception { get; set; }
    }
}
