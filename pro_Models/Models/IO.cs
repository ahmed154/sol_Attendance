using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_Models.Models
{
    public class IO
    {
        public int Id { get; set; }
        [Required]
        public string Index => EmpNumber + " " + TTime.ToString("yyyy-MM-dd HH:mm:ss");
        [Required]
        public DateTime TTime { get; set; }
        [Required]
        public int Event { get; set; } = 0;
        [Required]
        public string EmpNumber { get; set; }
        public string DeviceNumber { get; set; } = "No device ID";
        public bool Priority { get; set; }
        public bool Deleted { get; set; }
        //////////////////////////////////Relation
        //public Employee Emp { get; set; }
        //public Device Device { get; set; }
    }
}
