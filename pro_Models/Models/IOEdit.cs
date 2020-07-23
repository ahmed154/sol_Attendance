using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_Models.Models
{
    public class IOEdit
    {
        public int Id { get; set; }
        public string Index { get; set; }
        public DateTime TTime { get; set; }
        public int Event { get; set; }
        public int EmpId { get; set; }
        public int DeviceId { get; set; }
        public DateTime EditTime { get; set; }
        public string UserId { get; set; }
        //////////////////////////////////Relation
        public Employee Emp { get; set; }
        public Device Device { get; set; }
    }
}
