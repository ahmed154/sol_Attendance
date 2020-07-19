using pro_Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pro_Models.ViewModels
{
    public class DepartViewModel
    {
        [ValidateComplexType]
        public Depart Depart { get; set; } = new Depart();
        public string Exception { get; set; }
    }
}
