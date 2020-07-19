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
        public string Index { get; set; }
        [Required]
        public DateTime TTime { get; set; }
        [Required]
        public int Event { get; set; }
        [Required]
        public int EmpId { get; set; }
        [Required]
        public string DeviceId { get; set; }
        public bool Priority { get; set; }
        public bool Deleted { get; set; }
        //////////////////////////////////Relation
        public Emp Emp { get; set; }
        public Device Device { get; set; }
    }
}
