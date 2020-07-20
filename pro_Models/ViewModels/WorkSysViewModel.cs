using pro_Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace pro_Models.ViewModels
{
    public class WorkSysViewModel
    {
        [ValidateComplexType]
        public WorkSys WorkSys { get; set; } = new WorkSys();
        public string Exception { get; set; }
    }
}
