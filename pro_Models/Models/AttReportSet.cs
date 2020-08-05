using System;
using System.Collections.Generic;
using System.Text;

namespace pro_Models.Models
{
    public class AttReportSet
    {
        public int Id { get; set; }
        public bool Date { get; set; } = true;
        public bool Day { get; set; } = true;
        public bool Attend1 { get; set; } = true;
        public bool EarlyAttend1 { get; set; } = true;
        public bool Late1 { get; set; } = true;
        public bool Depart1 { get; set; } = true;
        public bool EarlyDepart1 { get; set; } = true;
        public bool Bonus1 { get; set; } = true;
        public bool Shift1 { get; set; } = true;

        public bool Attend2 { get; set; } = false;
        public bool EarlyAttend2 { get; set; } = false;
        public bool Late2 { get; set; } = false;
        public bool Depart2 { get; set; } = false;
        public bool EarlyDepart2 { get; set; } = false;
        public bool Bonus2 { get; set; } = false;
        public bool Shift2 { get; set; } = false;

        public bool Early { get; set; } = false;
        public bool Late { get; set; } = false;
        public bool EarlyDepart { get; set; } = false;
        public bool Bonus { get; set; } = false;

        public bool TotalTime { get; set; } = false;
        public bool TotalSubtract { get; set; } = false;
        public bool TotalSupplement { get; set; } = false;

        public bool TotalHours { get; set; } = false;
        public bool Holiday { get; set; } = false;
        public bool Absent { get; set; } = false;
        public bool AttendDevice { get; set; } = false;
        public bool DepartDevice { get; set; } = false;
        public bool Worksys { get; set; } = false;
        public bool BonusType { get; set; } = false;
        public bool UpdatedActions { get; set; } = false;

        public string UserEmail { get; set; }
    }
}
