using System;
using System.Collections.Generic;
using System.Text;

namespace pro_Models.ViewModels
{
    public class AttendanceReportViewModel
    {
        public string Date { get; set; }
        public string Day { get; set; }

        public string Attend1 { get; set; }
        public string EarlyAttend1 { get; set; }
        public string Late1 { get; set; }
        public string Depart1 { get; set; }
        public string EarlyDepart1 { get; set; }
        public string Bonus1 { get; set; }
        public string Shift1 { get; set; }

        public string Attend2 { get; set; }
        public string EarlyAttend2 { get; set; }
        public string Late2 { get; set; }
        public string Depart2 { get; set; }
        public string EarlyDepart2 { get; set; }
        public string Bonus2 { get; set; }
        public string Shift2 { get; set; }


        public string Early { get; set; }
        public string Late { get; set; }
        public string EarlyDepart { get; set; }
        public string Bonus { get; set; }


        public string TotalTime { get; set; }
        public string TotalSubtract { get; set; }
        public string TotalSupplement { get; set; }


        public string TotalHours { get; set; }
        public string Holiday { get; set; }
        public string Absent { get; set; }
        public string AttendDevice { get; set; }
        public string DepartDevice { get; set; }
        public string Worksys { get; set; }
        public string BonusType { get; set; }
        public string UpdatedActions { get; set; }
    }
}
