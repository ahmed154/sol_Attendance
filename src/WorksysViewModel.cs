using pro_Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace pro_Models.ViewModels
{
    public class WorksysViewModel
    {
        [ValidateComplexType]
        public Worksys Worksys { get; set; } = new Worksys();
        public string Exception { get; set; }
    }
}
