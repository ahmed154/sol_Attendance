using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_Models.Models
{
    public class Worksys
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Day_Hours { get; set; } = 24;
        public int Day_Min { get; set; } = 0;
        public DateTime? End { get; set; }  = new DateTime(0001, 01, 01, 0, 0, 0);
        public bool ti { get; set; } = false;
        public decimal First_as { get; set; } = 2;
        public decimal First_ae { get; set; } = 2;
        public decimal First_ls { get; set; } = 2;
        public decimal First_le { get; set; } = 2;
        public decimal Second_as { get; set; } = 2;
        public decimal Second_ae { get; set; } = 2;
        public decimal Second_ls { get; set; } = 2;
        public decimal Second_le { get; set; } = 2;
        public DateTime? saPeriod_Hours { get; set; }
        public bool saType { get; set; } = false;
        public bool sah { get; set; } = false;
        public bool saBonus { get; set; } = false;
        public bool saf { get; set; } = true;
        public DateTime? safs { get; set; }
        public DateTime? safe { get; set; }
        public DateTime? safa { get; set; }
        public bool sas { get; set; } = false;
        public DateTime? sass { get; set; }
        public DateTime? sase { get; set; }
        public DateTime? sasa { get; set; }
        public DateTime? suPeriod_Hours { get; set; } 
        public bool suType { get; set; } = false;
        public bool suh { get; set; } = false;
        public bool suBonus { get; set; } = false;
        public bool suf { get; set; } = true;
        public DateTime? sufs { get; set; }
        public DateTime? sufe { get; set; }
        public DateTime? sufa { get; set; }
        public bool sus { get; set; } = false;
        public DateTime? suss { get; set; }
        public DateTime? suse { get; set; }
        public DateTime? susa { get; set; }
        public DateTime? moPeriod_Hours { get; set; }
        public bool moType { get; set; } = false;
        public bool moh { get; set; } = false;
        public bool moBonus { get; set; } = false;
        public bool mof { get; set; } = true;
        public DateTime? mofs { get; set; }
        public DateTime? mofe { get; set; }
        public DateTime? mofa { get; set; }
        public bool mos { get; set; } = false;
        public DateTime? moss { get; set; }
        public DateTime? mose { get; set; }
        public DateTime? mosa { get; set; }
        public DateTime? tuPeriod_Hours { get; set; }
        public bool tuType { get; set; } = false;
        public bool tuh { get; set; } = false;
        public bool tuBonus { get; set; } = false;
        public bool tuf { get; set; } = true;
        public DateTime? tufs { get; set; }
        public DateTime? tufe { get; set; }
        public DateTime? tufa { get; set; }
        public bool tus { get; set; } = false;
        public DateTime? tuss { get; set; }
        public DateTime? tuse { get; set; }
        public DateTime? tusa { get; set; }
        public DateTime? wePeriod_Hours { get; set; }
        public bool weType { get; set; } = false;
        public bool weh { get; set; } = false;
        public bool weBonus { get; set; } = false;
        public bool wef { get; set; } = true;
        public DateTime? wefs { get; set; }
        public DateTime? wefe { get; set; }
        public DateTime? wefa { get; set; }
        public bool wes { get; set; } = false;
        public DateTime? wess { get; set; }
        public DateTime? wese { get; set; }
        public DateTime? wesa { get; set; }
        public DateTime? thPeriod_Hours { get; set; }
        public bool thType { get; set; } = false;
        public bool thh { get; set; } = false;
        public bool thBonus { get; set; } = false;
        public bool thf { get; set; } = true;
        public DateTime? thfs { get; set; }
        public DateTime? thfe { get; set; }
        public DateTime? thfa { get; set; }
        public bool ths { get; set; } = false;
        public DateTime? thss { get; set; }
        public DateTime? thse { get; set; }
        public DateTime? thsa { get; set; }
        public DateTime? frPeriod_Hours { get; set; }
        public bool frType { get; set; } = false;
        public bool frh { get; set; } = false;
        public bool frBonus { get; set; } = false;
        public bool frf { get; set; } = true;
        public DateTime? frfs { get; set; }
        public DateTime? frfe { get; set; }
        public DateTime? frfa { get; set; }
        public bool frs { get; set; } = false;
        public DateTime? frss { get; set; }
        public DateTime? frse { get; set; }
        public DateTime? rfsa { get; set; }
        public bool BonusCheck { get; set; } = true;
        public bool LateCheck { get; set; } = true;
        public bool AttEarly { get; set; } = false;
        public bool LeaveEarly { get; set; } = false;  
    }
}
