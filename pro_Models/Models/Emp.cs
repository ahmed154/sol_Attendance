using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_Models.Models
{
    public class Emp
    {
        public int Id { get; set; }
        public string Number { get; set; }
        [Required]
        public string Name { get; set; }
        public string DeviceId { get; set; }
        [Required]
        public int WSId { get; set; }
        public int Departd { get; set; }
        public int SecId { get; set; }
        //////////////////////////////////Relation
        public Device Device { get; set; }
        public Worksys WorkSys { get; set; }
        public Depart Depart { get; set; }
        public Sec Sec { get; set; }
    }
}
