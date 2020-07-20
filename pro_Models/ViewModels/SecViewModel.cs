using pro_Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace pro_Models.ViewModels
{
    public class SecViewModel
    {
        [ValidateComplexType]
        public Sec Sec { get; set; } = new Sec();
        public string Exception { get; set; }
    }
}
