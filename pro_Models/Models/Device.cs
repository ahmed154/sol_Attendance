using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_Models.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Number { get; set; }
        [Required]
        public string Name { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }
    }
}
