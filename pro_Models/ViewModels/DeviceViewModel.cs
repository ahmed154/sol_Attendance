using pro_Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace pro_Models.ViewModels
{
    public class DeviceViewModel
    {
        [ValidateComplexType]
        public Device Device { get; set; }
        public string Exception { get; set; }
    }
}
