using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_Models.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Number { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int WorksysId { get; set; }
        public int? DepartId { get; set; }
        public int? SecId { get; set; }
        public int? DeviceId { get; set; }
        //////////////////////////////////Relation
        public Device Device { get; set; }
        public Worksys Worksys { get; set; }
        public Depart Depart { get; set; }
        public Sec Sec { get; set; }
    }
}
