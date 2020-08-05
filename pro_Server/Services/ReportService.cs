using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using pro_Models.Models;
using pro_Models.ViewModels;
using pro_Server.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace pro_Server.Services
{
    public class ReportService : IReportService
    {
        private readonly HttpClient httpClient;
        private readonly IHttpService httpService;
        private string url = "api/report";
        private JsonSerializerOptions defaultJsonSerializerOptions =>new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public ReportService(HttpClient httpClient, IHttpService httpService)
        {
            this.httpClient = httpClient;
            this.httpService = httpService;
        }
        #region Pro
        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<T>(responseString, options);
        }
        async Task<IEnumerable<DeviceViewModel>> GetDevices()
        {
            List<DeviceViewModel> deviceViewModels = new List<DeviceViewModel>();
            var response = await httpService.Get<List<DeviceViewModel>>("api/device");

            if (!response.Success)
            {
                deviceViewModels.Add(new DeviceViewModel { Exception = await response.GetBody() });
            }
            else
            {
                deviceViewModels = response.Response;
            }
            return deviceViewModels;
        }
        public string Per_Hours(string d, Worksys worksys)
        {
            switch (d)
            {
                case "Saturday":
                    return worksys.saPeriod_Hours.ToString();
                case "Sunday":
                    return worksys.suPeriod_Hours.ToString();
                case "Monday":
                    return worksys.moPeriod_Hours.ToString();
                case "Tuesday":
                    return worksys.tuPeriod_Hours.ToString();
                case "Wednesday":
                    return worksys.wePeriod_Hours.ToString();
                case "Thursday":
                    return worksys.thPeriod_Hours.ToString();
                case "Friday":
                    return worksys.frPeriod_Hours.ToString();

                default:
                    return "";
            }
        }
        public string Day(string d)
            {
                switch (d)
                {
                    case "Saturday":
                        return "«·”» ";
                    case "Sunday":
                        return "«·√Õœ";
                    case "Monday":
                        return "«·√À‰Ì‰";
                    case "Tuesday":
                        return "«·À·«À«¡";
                    case "Wednesday":
                        return "«·√—»⁄«¡";
                    case "Thursday":
                        return "«·Œ„Ì”";
                    case "Friday":
                        return "«·Ã„⁄…";

                    default:
                        return "";
                }
            }
        public DateTime ToDateTime(object txt)
        {
            DateTime newDate = System.DateTime.ParseExact(
                txt.ToString(),
                "yyyy-MM-dd HH-mm-ss",
                CultureInfo.InvariantCulture);
            return newDate;
        }
        public bool Holiday(string d, Worksys worksys)
        {
            switch (d)
            {
                case "Saturday":
                    return Convert.ToBoolean(worksys.sah);
                case "Sunday":
                    return Convert.ToBoolean(worksys.suh);
                case "Monday":
                    return Convert.ToBoolean(worksys.moh);
                case "Tuesday":
                    return Convert.ToBoolean(worksys.tuh);
                case "Wednesday":
                    return Convert.ToBoolean(worksys.weh);
                case "Thursday":
                    return Convert.ToBoolean(worksys.thh);
                case "Friday":
                    return Convert.ToBoolean(worksys.frh);

                default:
                    return false;
            }
        }
        public bool Bonus(string d, Worksys worksys)
        {
            switch (d)
            {
                case "Saturday":
                    return Convert.ToBoolean(worksys.saBonus);
                case "Sunday":
                    return Convert.ToBoolean(worksys.suBonus);
                case "Monday":
                    return Convert.ToBoolean(worksys.moBonus);
                case "Tuesday":
                    return Convert.ToBoolean(worksys.tuBonus);
                case "Wednesday":
                    return Convert.ToBoolean(worksys.weBonus);
                case "Thursday":
                    return Convert.ToBoolean(worksys.thBonus);
                case "Friday":
                    return Convert.ToBoolean(worksys.frBonus);

                default:
                    return true;
            }
        }
        public bool Fixed(string d, Worksys worksys)
        {
            switch (d)
            {
                case "Saturday":
                    return Convert.ToBoolean(worksys.saType);
                case "Sunday":
                    return Convert.ToBoolean(worksys.suType);
                case "Monday":
                    return Convert.ToBoolean(worksys.moType);
                case "Tuesday":
                    return Convert.ToBoolean(worksys.tuType);
                case "Wednesday":
                    return Convert.ToBoolean(worksys.weType);
                case "Thursday":
                    return Convert.ToBoolean(worksys.thType);
                case "Friday":
                    return Convert.ToBoolean(worksys.frType);

                default:
                    return true;
            }
        }
        public string WS_start(string d, Worksys worksys)
        {
            switch (d)
            {
                case "Saturday":
                    return Convert.ToDateTime(worksys.safs).ToString("HH:mm");
                case "Sunday":
                    return Convert.ToDateTime(worksys.sufs).ToString("HH:mm");
                case "Monday":
                    return Convert.ToDateTime(worksys.mofs).ToString("HH:mm");
                case "Tuesday":
                    return Convert.ToDateTime(worksys.tufs).ToString("HH:mm");
                case "Wednesday":
                    return Convert.ToDateTime(worksys.wefs).ToString("HH:mm");
                case "Thursday":
                    return Convert.ToDateTime(worksys.thfs).ToString("HH:mm");
                case "Friday":
                    return Convert.ToDateTime(worksys.frfs).ToString("HH:mm");
                default:
                    return Convert.ToDateTime(worksys.safs).ToString("HH:mm");
            }
        }
        public string WS_start2(string d, Worksys worksys)
        {
            switch (d)
            {
                case "Saturday":
                    return Convert.ToDateTime(worksys.sass).ToString("HH:mm");
                case "Sunday":
                    return Convert.ToDateTime(worksys.suss).ToString("HH:mm");
                case "Monday":
                    return Convert.ToDateTime(worksys.moss).ToString("HH:mm");
                case "Tuesday":
                    return Convert.ToDateTime(worksys.tuss).ToString("HH:mm");
                case "Wednesday":
                    return Convert.ToDateTime(worksys.wess).ToString("HH:mm");
                case "Thursday":
                    return Convert.ToDateTime(worksys.thss).ToString("HH:mm");
                case "Friday":
                    return Convert.ToDateTime(worksys.frss).ToString("HH:mm");
                default:
                    return Convert.ToDateTime(worksys.sass).ToString("HH:mm");
            }
        }
        public string WS_end(string d, Worksys worksys)
        {
            switch (d)
            {
                case "Saturday":
                    return Convert.ToDateTime(worksys.safe).ToString("HH:mm");
                case "Sunday":
                    return Convert.ToDateTime(worksys.sufe).ToString("HH:mm");
                case "Monday":
                    return Convert.ToDateTime(worksys.mofe).ToString("HH:mm");
                case "Tuesday":
                    return Convert.ToDateTime(worksys.tufe).ToString("HH:mm");
                case "Wednesday":
                    return Convert.ToDateTime(worksys.wefe).ToString("HH:mm");
                case "Thursday":
                    return Convert.ToDateTime(worksys.thfe).ToString("HH:mm");
                case "Friday":
                    return Convert.ToDateTime(worksys.frfe).ToString("HH:mm");
                default:
                    return Convert.ToDateTime(worksys.safe).ToString("HH:mm");
            }
        }
        public string WS_end2(string d, Worksys worksys)
        {
            switch (d)
            {
                case "Saturday":
                    return Convert.ToDateTime(worksys.sase).ToString("HH:mm");
                case "Sunday":
                    return Convert.ToDateTime(worksys.suse).ToString("HH:mm");
                case "Monday":
                    return Convert.ToDateTime(worksys.mose).ToString("HH:mm");
                case "Tuesday":
                    return Convert.ToDateTime(worksys.tuse).ToString("HH:mm");
                case "Wednesday":
                    return Convert.ToDateTime(worksys.wese).ToString("HH:mm");
                case "Thursday":
                    return Convert.ToDateTime(worksys.thse).ToString("HH:mm");
                case "Friday":
                    return Convert.ToDateTime(worksys.frse).ToString("HH:mm");
                default:
                    return Convert.ToDateTime(worksys.sase).ToString("HH:mm");
            }
        }

        public TimeSpan WS_Start(string d, Worksys worksys)
        {
            switch (d)
            {
                case "Saturday":
                    return Convert.ToDateTime(worksys.safs).TimeOfDay;
                case "Sunday":
                    return Convert.ToDateTime(worksys.sufs).TimeOfDay;
                case "Monday":
                    return Convert.ToDateTime(worksys.mofs).TimeOfDay;
                case "Tuesday":
                    return Convert.ToDateTime(worksys.tufs).TimeOfDay;
                case "Wednesday":
                    return Convert.ToDateTime(worksys.wefs).TimeOfDay;
                case "Thursday":
                    return Convert.ToDateTime(worksys.thfs).TimeOfDay;
                case "Friday":
                    return Convert.ToDateTime(worksys.frfs).TimeOfDay;
                default:
                    return Convert.ToDateTime(worksys.safs).TimeOfDay;
            }
        }
        public TimeSpan WS_Start2(string d, Worksys worksys)
        {
            switch (d)
            {
                case "Saturday":
                    return Convert.ToDateTime(worksys.sass).TimeOfDay;
                case "Sunday":
                    return Convert.ToDateTime(worksys.suss).TimeOfDay;
                case "Monday":
                    return Convert.ToDateTime(worksys.moss).TimeOfDay;
                case "Tuesday":
                    return Convert.ToDateTime(worksys.tuss).TimeOfDay;
                case "Wednesday":
                    return Convert.ToDateTime(worksys.wess).TimeOfDay;
                case "Thursday":
                    return Convert.ToDateTime(worksys.thss).TimeOfDay;
                case "Friday":
                    return Convert.ToDateTime(worksys.frss).TimeOfDay;
                default:
                    return Convert.ToDateTime(worksys.sass).TimeOfDay;
            }
        }
        public TimeSpan WS_End(string d, Worksys worksys)
        {
            switch (d)
            {
                case "Saturday":
                    return Convert.ToDateTime(worksys.safe).TimeOfDay;
                case "Sunday":
                    return Convert.ToDateTime(worksys.sufe).TimeOfDay;
                case "Monday":
                    return Convert.ToDateTime(worksys.mofe).TimeOfDay;
                case "Tuesday":
                    return Convert.ToDateTime(worksys.tufe).TimeOfDay;
                case "Wednesday":
                    return Convert.ToDateTime(worksys.wefe).TimeOfDay;
                case "Thursday":
                    return Convert.ToDateTime(worksys.thfe).TimeOfDay;
                case "Friday":
                    return Convert.ToDateTime(worksys.frfe).TimeOfDay;
                default:
                    return Convert.ToDateTime(worksys.safe).TimeOfDay;
            }
        }
        public TimeSpan WS_End2(string d, Worksys worksys)
        {
            switch (d)
            {
                case "Saturday":
                    return Convert.ToDateTime(worksys.sase).TimeOfDay;
                case "Sunday":
                    return Convert.ToDateTime(worksys.suse).TimeOfDay;
                case "Monday":
                    return Convert.ToDateTime(worksys.mose).TimeOfDay;
                case "Tuesday":
                    return Convert.ToDateTime(worksys.tuse).TimeOfDay;
                case "Wednesday":
                    return Convert.ToDateTime(worksys.wese).TimeOfDay;
                case "Thursday":
                    return Convert.ToDateTime(worksys.thse).TimeOfDay;
                case "Friday":
                    return Convert.ToDateTime(worksys.frse).TimeOfDay;
                default:
                    return Convert.ToDateTime(worksys.sase).TimeOfDay;
            }
        }
        string Per(DataRow r, int i)
        {
            string d = r["«· «—ÌŒ"].ToString();
            string p = "";

            #region Per1
            if (i == 1) // «·› —… «·√Ê·Ï
            {
                string t = r["Õ÷Ê— œÊ«„ 1"].ToString();
                string dt = d + " " + t;
                DateTime d1 = Convert.ToDateTime(dt);

                string d2s = r["≈‰’—«› œÊ«„ 1"].ToString();
                DateTime d2 = Convert.ToDateTime(d2s);
                if (d2s.Length == 8)
                {
                    t = r["≈‰’—«› œÊ«„ 1"].ToString();
                    dt = d + " " + t;
                    d2 = Convert.ToDateTime(dt);
                }

                TimeSpan tt = d2 - d1;
                p = ttos(tt);
            }
            #endregion

            #region Per2
            else // «·› —… «·À«‰Ì…
            {
                string t = r["Õ÷Ê— œÊ«„ 2"].ToString();
                string dt = d + " " + t;
                DateTime d1 = Convert.ToDateTime(dt);

                string d2s = r["≈‰’—«› œÊ«„ 2"].ToString();
                DateTime d2 = Convert.ToDateTime(d2s);
                if (d2s.Length == 8)
                {
                    t = r["≈‰’—«› œÊ«„ 2"].ToString();
                    dt = d + " " + t;
                    d2 = Convert.ToDateTime(dt);
                }

                TimeSpan tt = d2 - d1;

                p = ttos(tt);
            }
            #endregion

            return p;
        }
        string ttos(TimeSpan tt)
        {
            int d = tt.Days;
            int h = tt.Hours;
            int m = tt.Minutes;
            while (d > 0)
            {
                d--;
                h += 24;
            }
            string hh = addzero(h.ToString());
            string mm = addzero(m.ToString());

            string t = hh + ":" + mm;
            return t;
        }
        TimeSpan t(DataRow r, int i, DateTime m)
        {
            string d = r["«· «—ÌŒ"].ToString();
            string t = (i == 1) ? r["Õ÷Ê— œÊ«„ 1"].ToString() : r["Õ÷Ê— œÊ«„ 2"].ToString();
            string dt = d + " " + t;
            DateTime d1 = Convert.ToDateTime(dt);

            DateTime d2 = m;
            if (d2.ToString().Length == 8)
            {
                t = m.ToString();
                dt = d + " " + t;
                d2 = Convert.ToDateTime(dt);
            }
            TimeSpan result = d2 - d1;
            return result;
        }
        string sum(string f, string s)
        {
            if (f == "") f = "00:00";
            if (s == "") s = "00:00";

            int ih = 0;
            while ((f.Substring(ih, 1) != ":"))
            {
                ih++;
            }
            int im = ih + 1;

            int h = Convert.ToInt32(f.Substring(0, ih)) + Convert.ToInt32(s.Substring(0, 2));
            int m = Convert.ToInt32(f.Substring(im, 2)) + Convert.ToInt32(s.Substring(3, 2));
            while (m >= 60)
            {
                h += 1;
                m -= 60;
            }

            string hh = addzero(h.ToString());
            string mm = addzero(m.ToString());

            string t = hh + ":" + mm;
            return t;
        }
        string sub(string r, string p)
        {
            if (p == "") p = "00:00";

            int h = Convert.ToUInt16(r.Substring(0, 2)) - Convert.ToUInt16(p.Substring(0, 2));
            int m = Convert.ToUInt16(r.Substring(3, 2)) - Convert.ToUInt16(p.Substring(3, 2));
            while (m < 0)
            {
                h -= 1;
                m += 60;
            }

            string hh = addzero(h.ToString());
            string mm = addzero(m.ToString());

            string t = hh + ":" + mm;
            return t;
        }
        private bool com(string r, string p)
        {
            if (r == "") return false;
            if (p == "") p = "00:00";
            if (Convert.ToInt32(r.Substring(0, 2)) > Convert.ToInt32(p.Substring(0, 2)))
            {
                return true;
            }
            else if (Convert.ToInt32(r.Substring(0, 2)) == Convert.ToInt32(p.Substring(0, 2)))
            {
                if (Convert.ToInt32(r.Substring(3, 2)) > Convert.ToInt32(p.Substring(3, 2)))
                {
                    return true;
                }
            }
            return false;
        }
        string addzero(string s)
        {
            s = (s.Length == 1) ? "0" + s : s;
            return s;
        }
        string addzeroEmpID(string s)
        {
            while (s.Length < 9)
            {
                s = "0" + s;
            }
            return s;
        }
        #endregion

        public async Task<ReportViewModel> GetReportViewModel(ReportViewModel reportViewModel)
        {
            reportViewModel.Exception = null;
            var dataJson = System.Text.Json.JsonSerializer.Serialize(reportViewModel);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var responseHTTP = await httpClient.PostAsync(url, stringContent);

            if (responseHTTP.IsSuccessStatusCode)
            {
                reportViewModel = await Deserialize<ReportViewModel>(responseHTTP, defaultJsonSerializerOptions);
            }
            else
            {
                reportViewModel.Exception = await responseHTTP.Content.ReadAsStringAsync();
            }
            reportViewModel.IOs = reportViewModel.IOs.OrderBy(x => x.TTime).ToList();
            DateTime currentDate;
            DateTime lastDate = (reportViewModel.IOs.Count > 0) ? reportViewModel.IOs[0].TTime : DateTime.Now; ;
            for (int i = 0; i < reportViewModel.IOs.Count; i++)
            {
                currentDate = reportViewModel.IOs[i].TTime;
                if (currentDate.Date != lastDate.Date)
                {
                    reportViewModel.IOs.Insert(i, null);
                    lastDate = currentDate;
                }
            }

            return reportViewModel;
        }
        public async Task<List<AttendanceReportViewModel>> GetAttendanceReport(ReportViewModel reportViewModel)
        {
            #region Preparing
            Device Device = new Device();
            IO IO = new IO();

            string sh = "hh:mm tt";
            string sd = "yyyy-MM-dd";
            string l = "yyyy-MM-dd hh:mm tt";

            bool ignore_l1 = false;
            bool ignore_l2 = false;

            Dictionary<string, string> myDict = new Dictionary<string, string>(); // Devices
            myDict.Add("No Device", "No Device");
            List<DeviceViewModel> devicesVM = (List<DeviceViewModel>)await GetDevices();
            foreach (DeviceViewModel devicevm in devicesVM)
            {
                myDict.Add(devicevm.Device.Number, devicevm.Device.Name);
            }
            string Device_Name;

            reportViewModel = await GetReportViewModel(reportViewModel); // «·Õ—ﬂ« 

            int Day_Hours = Convert.ToInt32(reportViewModel.Worksys.Day_Hours); // · ÕœÌœ ‰Â«Ì… «·»Ê„
            int Day_Min = Convert.ToInt32(reportViewModel.Worksys.Day_Min); // · ÕœÌœ ‰Â«Ì… «·»Ê„
            bool ti = Convert.ToBoolean(reportViewModel.Worksys.ti); //  ÕœÌœ Â· ÌÕœœ ‰Ê⁄ «·Õ—ﬂ… «·Õ—ﬂ… »Õ”» «·Êﬁ 

            #region dt_att
            DataTable dt_att = new DataTable(); // «·Õ÷Ê— Ê«·≈‰’—«›
            dt_att.Columns.Add("«· «—ÌŒ", typeof(string));
            dt_att.Columns.Add("«·ÌÊ„", typeof(string));

            dt_att.Columns.Add("Õ÷Ê— œÊ«„ 1", typeof(string));
            dt_att.Columns.Add("Õ÷Ê— „»ﬂ—1", typeof(string));
            dt_att.Columns.Add(" √ŒÌ—1", typeof(string));
            dt_att.Columns.Add("≈‰’—«› œÊ«„ 1", typeof(string));
            dt_att.Columns.Add("≈‰’—«› „»ﬂ—1", typeof(string));
            dt_att.Columns.Add("≈÷«›Ì1", typeof(string));
            dt_att.Columns.Add("«·› —… «·√Ê·Ï", typeof(string));

            dt_att.Columns.Add("Õ÷Ê— œÊ«„ 2", typeof(string));
            dt_att.Columns.Add("Õ÷Ê— „»ﬂ—2", typeof(string));
            dt_att.Columns.Add(" √ŒÌ—2", typeof(string));
            dt_att.Columns.Add("≈‰’—«› œÊ«„ 2", typeof(string));
            dt_att.Columns.Add("≈‰’—«› „»ﬂ—2", typeof(string));
            dt_att.Columns.Add("≈÷«›Ì2", typeof(string));
            dt_att.Columns.Add("«·› —… «·À«‰Ì…", typeof(string));

            dt_att.Columns.Add("Õ÷Ê— „»ﬂ—", typeof(string));
            dt_att.Columns.Add(" √ŒÌ—", typeof(string));
            dt_att.Columns.Add("≈‰’—«› „»ﬂ—", typeof(string));
            dt_att.Columns.Add("≈÷«›Ì", typeof(string));

            dt_att.Columns.Add("«·œÊ«„", typeof(string));
            dt_att.Columns.Add("≈Ã„«·Ì «·„” ﬁÿ⁄", typeof(string));
            dt_att.Columns.Add("≈Ã„«·Ì «·„÷«›", typeof(string));

            dt_att.Columns.Add("⁄œœ «·”«⁄« ", typeof(string));
            dt_att.Columns.Add("√Ã«“… ø", typeof(string));
            dt_att.Columns.Add("€«∆» ø", typeof(string));
            dt_att.Columns.Add("ÃÂ«“ «·Õ÷Ê—", typeof(string));
            dt_att.Columns.Add("ÃÂ«“ «·≈‰’—«›", typeof(string));
            dt_att.Columns.Add("‰Ÿ«„ «·„Ê«⁄Ìœ", typeof(string));
            dt_att.Columns.Add("‰Ê⁄ «·≈÷«›Ì", typeof(string));
            dt_att.Columns.Add("Õ—ﬂ«  „⁄œ·…", typeof(string));
            #endregion

            int days_count = Convert.ToInt32((reportViewModel.ToDate - reportViewModel.FromDate).TotalDays);
            if (days_count == 0) days_count = 1;
            #endregion

            #region IO
            for (int i = 0; i < days_count; i++) // IO Loop
            {
                dt_att.Rows.Add(reportViewModel.FromDate.AddDays(i).ToString("yyyy-MM-dd"), Day(reportViewModel.FromDate.AddDays(i).ToString("dddd"))); // Add Date & Day
                string day = Convert.ToDateTime(dt_att.Rows[dt_att.Rows.Count - 1]["«· «—ÌŒ"]).ToString("dddd");
                string y = dt_att.Rows[i][0].ToString(); //  «—ÌŒ «·’›
                DateTime ds = Convert.ToDateTime(y); // »œ«Ì…  «—ÌŒ «·’›
                DateTime de = Convert.ToDateTime(y).AddHours(Day_Hours);
                de = de.AddMinutes(Day_Min); //  ‰Â«Ì…  «—ÌŒ «·’›

                for (int p = 0; p < reportViewModel.IOs.Count; p++) // IO Loop2
                {
                    if (reportViewModel.IOs[p] == null)
                    {
                        continue;
                    }
                    #region Preparing
                    string io_day = Convert.ToDateTime(reportViewModel.IOs[p].TTime).ToString("dddd"); // ÌÊ„ «·Õ—ﬂ…


                    string x = Convert.ToDateTime(reportViewModel.IOs[p].TTime).ToString("yyyy-MM-dd"); //  «—ÌŒ «·Õ—ﬂ…
                    DateTime m = Convert.ToDateTime(reportViewModel.IOs[p].TTime); //  «—ÌŒ ÊÊﬁ  «·Õ—ﬂ…
                    int m_action = m.Hour;
                    m_action = (Convert.ToDateTime(reportViewModel.IOs[p].TTime).ToString(sd) == y) ? m_action : m_action + 24;

                    int fs = Convert.ToDateTime(WS_start(io_day, reportViewModel.Worksys)).Hour;
                    int fe = Convert.ToDateTime(WS_end(io_day, reportViewModel.Worksys)).Hour;
                    int ss = Convert.ToDateTime(WS_start2(io_day, reportViewModel.Worksys)).Hour;
                    int se = Convert.ToDateTime(WS_end2(io_day, reportViewModel.Worksys)).Hour;

                    if (m_action >= 24)
                    {
                        string io_prevday = Convert.ToDateTime(reportViewModel.IOs[p].TTime).AddDays(-1).ToString("dddd"); // «·ÌÊ„ «·”«»ﬁ
                        fs = Convert.ToDateTime(WS_start(io_prevday, reportViewModel.Worksys)).Hour;
                        fe = Convert.ToDateTime(WS_end(io_prevday, reportViewModel.Worksys)).Hour;
                        ss = Convert.ToDateTime(WS_start2(io_prevday, reportViewModel.Worksys)).Hour;
                        se = Convert.ToDateTime(WS_end2(io_prevday, reportViewModel.Worksys)).Hour;
                    }

                    int First_as = fs - Convert.ToInt32(reportViewModel.Worksys.First_as);
                    int First_ae = fs + Convert.ToInt32(reportViewModel.Worksys.First_ae);
                    int First_ls = fe - Convert.ToInt32(reportViewModel.Worksys.First_ls);
                    int First_le = fe + Convert.ToInt32(reportViewModel.Worksys.First_le);
                    int Second_as = ss - Convert.ToInt32(reportViewModel.Worksys.Second_as);
                    int Second_ae = ss + Convert.ToInt32(reportViewModel.Worksys.Second_ae);
                    int Second_ls = se - Convert.ToInt32(reportViewModel.Worksys.Second_ls);
                    int Second_le = se + Convert.ToInt32(reportViewModel.Worksys.Second_le);
                    #endregion

                    if (ti == true && Fixed(day, reportViewModel.Worksys) == false) // ÌÕœœ ‰Ê⁄ «·Õ—ﬂ… »Õ”» «·Êﬁ  Ê‰Ÿ«„ À«» 
                    {

                        if (m_action >= First_as && m_action <= First_ae && x == y) // Õ÷Ê— œÊ«„ 1
                        {
                            reportViewModel.IOs[p].Event = 0;
                        }
                        else if (m_action >= First_ls && m_action <= First_le && m >= ds && m <= de && t(dt_att.Rows[i], 1, m) > TimeSpan.Parse("0.00:00:00")) // ≈‰’—«› œÊ«„ 1
                        {
                            reportViewModel.IOs[p].Event = 1;
                        }
                        else if (m_action >= Second_as && m_action <= Second_ae && x == y) // Õ÷Ê— œÊ«„ 2
                        {
                            reportViewModel.IOs[p].Event = 0;
                        }
                        else if (m_action >= Second_ls && m_action <= Second_le && m >= ds && m <= de && t(dt_att.Rows[i], 2, m) > TimeSpan.Parse("0.00:00:00")) // ≈‰’—«› œÊ«„ 2
                        {
                            reportViewModel.IOs[p].Event = 1;
                        }

                        #region Õ÷Ê— œÊ«„ 1
                        if (reportViewModel.IOs[p].Event.ToString() == "0" && m_action >= First_as && m_action <= First_ae && x == y) // Õ÷Ê— œÊ«„ 1
                        {
                            if (dt_att.Rows[i]["Õ÷Ê— œÊ«„ 1"].ToString() == "") // ≈–« ﬂ«‰ ·« ÌÊÃœ Õ÷Ê—
                            {
                                dt_att.Rows[i]["Õ÷Ê— œÊ«„ 1"] = Convert.ToDateTime(reportViewModel.IOs[p].TTime).ToString(sh);

                                #region Õ÷Ê— „»ﬂ— Ê  √ŒÌ—       
                                string start1 = WS_start(io_day, reportViewModel.Worksys);
                                if (com(start1, m.ToString("HH:mm")) == true) // ≈–« ﬂ«‰ Êﬁ  «·Õ÷Ê— ›Ì ‰Ÿ«„ «·œÊ«„ √ﬂ»— „‰ Êﬁ  Õ÷Ê— «·„ÊŸ›
                                {
                                    string attearly = sub(start1, m.ToString("HH:mm"));
                                    dt_att.Rows[i]["Õ÷Ê— „»ﬂ—1"] = attearly; // ÌÊÃœ Õ÷Ê— „»ﬂ—
                                }
                                else // ≈Õ ”«» «· √ŒÌ— ≈‰ ÊÃœ
                                {
                                    TimeSpan start = WS_Start(Convert.ToDateTime(dt_att.Rows[i]["«· «—ÌŒ"]).ToString("dddd"), reportViewModel.Worksys);
                                    TimeSpan att1 = Convert.ToDateTime(dt_att.Rows[i]["Õ÷Ê— œÊ«„ 1"]).TimeOfDay;

                                    TimeSpan Late = (att1 > start) ? (att1 - start) : TimeSpan.Parse("0.00:00:00");

                                    dt_att.Rows[i][" √ŒÌ—1"] = string.Format("{0:hh\\:mm}", Late);
                                    if (dt_att.Rows[i][" √ŒÌ—1"].ToString() == "00:00") dt_att.Rows[i][" √ŒÌ—1"] = "";
                                }
                                #endregion

                                #region ÃÂ«“ «·Õ÷Ê—
                                myDict.TryGetValue(reportViewModel.IOs[p].DeviceNumber, out Device_Name);
                                dt_att.Rows[i]["ÃÂ«“ «·Õ÷Ê—"] = Device_Name;
                                #endregion

                                #region Õ—ﬂ«  „⁄œ·…
                                //if (IO.Select_Cout(reportViewModel.IOs.Rows[p]["Index"].ToString()) > 0)
                                //{
                                //    dt_att.Rows[i]["Õ—ﬂ«  „⁄œ·…"] += " Õ÷Ê— œÊ«„ 1 ";
                                //}
                                #endregion
                            }

                            reportViewModel.IOs.RemoveAt(p); // Õ–› «·Õ—ﬂ…
                            p--;
                        }
                        #endregion

                        #region ≈‰’—«› œÊ«„ 1
                        else if (reportViewModel.IOs[p].Event.ToString() == "1" && m_action >= First_ls && m_action <= First_le && m >= ds && m <= de && t(dt_att.Rows[i], 1, m) > TimeSpan.Parse("0.00:00:00")) // ≈‰’—«› œÊ«„ 1
                        {
                            //if (dt_att.Rows[i]["Õ÷Ê— œÊ«„ 1"].ToString() == "") continue;
                            if (dt_att.Rows[i]["≈‰’—«› œÊ«„ 1"].ToString() != "" && ignore_l1 == true) continue;

                            string s = (Convert.ToDateTime(reportViewModel.IOs[p].TTime).ToString(sd) == y) ? sh : l;
                            dt_att.Rows[i]["≈‰’—«› œÊ«„ 1"] = Convert.ToDateTime(reportViewModel.IOs[p].TTime).ToString(s);

                            ignore_l1 = Convert.ToBoolean(reportViewModel.IOs[p].Priority);

                            #region  ≈‰’—«› „»ﬂ— Ê ≈÷«›Ì   
                            string end1 = WS_end(io_day, reportViewModel.Worksys);
                            if (m.ToString("yyyy-MM-dd") == y && com(end1, m.ToString("HH:mm")) == true) // ≈‰’—«› „»ﬂ— ø
                            {
                                string leavearly = sub(end1, m.ToString("HH:mm"));
                                dt_att.Rows[i]["≈‰’—«› „»ﬂ—1"] = leavearly;
                            }
                            else // ≈Õ ”«» «·≈÷«›Ì ≈‰ ÊÃœ
                            {
                                TimeSpan end = WS_End(Convert.ToDateTime(dt_att.Rows[i]["«· «—ÌŒ"]).ToString("dddd"), reportViewModel.Worksys);
                                TimeSpan leave = Convert.ToDateTime(dt_att.Rows[i]["≈‰’—«› œÊ«„ 1"]).TimeOfDay;
                                if (m.ToString("yyyy-MM-dd") != y) leave += TimeSpan.Parse("1.00:00:00"); // ≈–« ﬂ«‰ «·«‰’—«› ›Ì «·ÌÊ„ «· «·Ì

                                TimeSpan result = (leave > end) ? (leave - end) : TimeSpan.Parse("0.00:00:00");
                                string sresult = string.Format("{0:hh\\:mm}", result);

                                dt_att.Rows[i]["≈÷«›Ì1"] = sresult;
                                if (dt_att.Rows[i]["≈÷«›Ì1"].ToString() == "00:00") dt_att.Rows[i]["≈÷«›Ì1"] = "";
                            }
                            #endregion

                            #region ÃÂ«“ «·≈‰’—«›
                            myDict.TryGetValue(reportViewModel.IOs[p].DeviceNumber.ToString(), out Device_Name);
                            dt_att.Rows[i]["ÃÂ«“ «·≈‰’—«›"] = Device_Name;
                            #endregion

                            #region Õ—ﬂ«  „⁄œ·…
                            //if (IO.Select_Cout(reportViewModel.IOs.Rows[p]["Index"].ToString()) > 0)
                            //{
                            //    dt_att.Rows[i]["Õ—ﬂ«  „⁄œ·…"] += " ≈‰’—«› œÊ«„ 1 ";
                            //}
                            #endregion

                            reportViewModel.IOs.RemoveAt(p);
                            p--;
                        }
                        #endregion

                        #region Õ÷Ê— œÊ«„ 2
                        else if (reportViewModel.IOs[p].Event.ToString() == "0" && m_action >= Second_as && m_action <= Second_ae && x == y) // Õ÷Ê— œÊ«„ 2
                        {
                            string s = (Convert.ToDateTime(reportViewModel.IOs[p].TTime).ToString(sd) == y) ? sh : l;
                            if (dt_att.Rows[i]["Õ÷Ê— œÊ«„ 2"].ToString() == "") // ≈–« ﬂ«‰ ·« ÌÊÃœ Õ÷Ê—
                            {
                                dt_att.Rows[i]["Õ÷Ê— œÊ«„ 2"] = Convert.ToDateTime(reportViewModel.IOs[p].TTime).ToString(s);

                                #region Õ÷Ê— „»ﬂ— Ê  √ŒÌ—
                                string start2 = WS_start2(io_day, reportViewModel.Worksys);
                                if (com(start2, m.ToString("HH:mm")) == true) // ≈–« ﬂ«‰ ÌÊÃœ Õ÷Ê— „»ﬂ—
                                {
                                    string attearly = sub(start2, m.ToString("HH:mm"));

                                    dt_att.Rows[i]["Õ÷Ê— „»ﬂ—2"] = attearly;
                                }
                                else // ≈–« ﬂ«‰ ·« ÌÊÃœ Õ÷Ê— „»ﬂ—
                                {
                                    //if (reportViewModel.Worksys.Rows[0]["LateCheck"].ToString() == "True") // ≈–« ﬂ«‰ ÌÕ ”» «· √ŒÌ—
                                    //{
                                    TimeSpan start = WS_Start2(Convert.ToDateTime(dt_att.Rows[i]["«· «—ÌŒ"]).ToString("dddd"), reportViewModel.Worksys);
                                    TimeSpan att = Convert.ToDateTime(dt_att.Rows[i]["Õ÷Ê— œÊ«„ 2"]).TimeOfDay;

                                    TimeSpan Late = (att > start) ? (att - start) : TimeSpan.Parse("0.00:00:00");


                                    dt_att.Rows[i][" √ŒÌ—2"] = string.Format("{0:hh\\:mm}", Late);
                                    if (dt_att.Rows[i][" √ŒÌ—2"].ToString() == "00:00") dt_att.Rows[i][" √ŒÌ—2"] = "";
                                    //}
                                }
                                #endregion

                                #region Õ—ﬂ«  „⁄œ·…
                                //if (IO.Select_Cout(reportViewModel.IOs.Rows[p]["Index"].ToString()) > 0)
                                //{
                                //    dt_att.Rows[i]["Õ—ﬂ«  „⁄œ·…"] += " Õ÷Ê— œÊ«„ 2 ";
                                //}
                                #endregion
                            }

                            reportViewModel.IOs.RemoveAt(p);
                            p--;
                        }
                        #endregion

                        #region ≈‰’—«› œÊ«„ 2
                        else if (reportViewModel.IOs[p].Event.ToString() == "1" && m_action >= Second_ls && m_action <= Second_le && m >= ds && m <= de && t(dt_att.Rows[i], 2, m) > TimeSpan.Parse("0.00:00:00")) // ≈‰’—«› œÊ«„ 2
                        {
                            if (dt_att.Rows[i]["Õ÷Ê— œÊ«„ 2"].ToString() == "") continue;
                            if (dt_att.Rows[i]["≈‰’—«› œÊ«„ 2"].ToString() != "" && ignore_l2 == true) continue;

                            string s = (Convert.ToDateTime(reportViewModel.IOs[p].TTime).ToString(sd) == y) ? sh : l;
                            dt_att.Rows[i]["≈‰’—«› œÊ«„ 2"] = Convert.ToDateTime(reportViewModel.IOs[p].TTime).ToString(s);

                            ignore_l2 = Convert.ToBoolean(reportViewModel.IOs[p].Priority);

                            #region ≈‰’—«› „»ﬂ— Ê ≈÷«›Ì
                            string end2 = WS_end2(io_day, reportViewModel.Worksys);
                            if (m.ToString("yyyy-MM-dd") == y && com(end2, m.ToString("HH:mm")) == true) // ≈‰’—«› „»ﬂ—
                            {
                                string leavearly = sum(dt_att.Rows[i]["≈‰’—«› „»ﬂ—"].ToString(), sub(end2, m.ToString("HH:mm")));
                                dt_att.Rows[i]["≈‰’—«› „»ﬂ—2"] = leavearly;
                            }
                            else // ≈–« ·« ÌÊÃœ ≈‰’—«› „»ﬂ—
                            {
                                if (reportViewModel.Worksys.BonusCheck.ToString() == "True") // ≈÷«›Ì
                                {
                                    TimeSpan end = WS_End2(Convert.ToDateTime(dt_att.Rows[i]["«· «—ÌŒ"]).ToString("dddd"), reportViewModel.Worksys);
                                    TimeSpan leave = Convert.ToDateTime(dt_att.Rows[i]["≈‰’—«› œÊ«„ 2"]).TimeOfDay;
                                    if (m.ToString("yyyy-MM-dd") != y) leave += TimeSpan.Parse("1.00:00:00"); // ≈–« ﬂ«‰ «·«‰’—«› ›Ì «·ÌÊ„ «· «·Ì

                                    TimeSpan result = (leave > end) ? (leave - end) : TimeSpan.Parse("0.00:00:00");
                                    string sresult = string.Format("{0:hh\\:mm}", result);

                                    dt_att.Rows[i]["≈÷«›Ì2"] = sresult;
                                    if (dt_att.Rows[i]["≈÷«›Ì2"].ToString() == "00:00") dt_att.Rows[i]["≈÷«›Ì2"] = "";
                                }
                            }
                            #endregion

                            #region Õ—ﬂ«  „⁄œ·…
                            //if (IO.Select_Cout(reportViewModel.IOs.Rows[p]["Index"].ToString()) > 0)
                            //{
                            //    dt_att.Rows[i]["Õ—ﬂ«  „⁄œ·…"] += " ≈‰’—«› œÊ«„ 2";
                            //}
                            #endregion

                            reportViewModel.IOs.RemoveAt(p);
                            p--;
                        }
                        #endregion
                    }
                    else  // ·« ÌÕœœ ‰Ê⁄ «·Õ—ﬂ… »Õ”» «·Êﬁ  √Ê ‰Ÿ«„ €Ì— À«» 
                    {
                        #region Õ÷Ê— œÊ«„ 1
                        if (reportViewModel.IOs[p].Event.ToString() == "0" && x == y) // Õ÷Ê— œÊ«„ 1
                        {
                            if (dt_att.Rows[i]["Õ÷Ê— œÊ«„ 1"].ToString() == "") // ≈–« ﬂ«‰ ·« ÌÊÃœ Õ÷Ê—
                            {
                                dt_att.Rows[i]["Õ÷Ê— œÊ«„ 1"] = Convert.ToDateTime(reportViewModel.IOs[p].TTime).ToString(sh);

                                #region Õ÷Ê— „»ﬂ— Ê  √ŒÌ—
                                if (Fixed(io_day, reportViewModel.Worksys) == false) // ≈–« ﬂ«‰ ‰Ÿ«„ À«» 
                                {
                                    string start1 = WS_start(io_day, reportViewModel.Worksys);
                                    if (com(start1, m.ToString("HH:mm")) == true)
                                    {
                                        string attearly = sub(start1, m.ToString("HH:mm"));
                                        dt_att.Rows[i]["Õ÷Ê— „»ﬂ—"] = attearly; // ÌÊÃœ Õ÷Ê— „»ﬂ—
                                    }
                                    else // ≈Õ ”«» «· √ŒÌ— ≈‰ ÊÃœ
                                    {
                                        TimeSpan start = WS_Start(Convert.ToDateTime(dt_att.Rows[i]["«· «—ÌŒ"]).ToString("dddd"), reportViewModel.Worksys);
                                        TimeSpan att1 = Convert.ToDateTime(dt_att.Rows[i]["Õ÷Ê— œÊ«„ 1"]).TimeOfDay;

                                        TimeSpan Late = (att1 > start) ? (att1 - start) : TimeSpan.Parse("0.00:00:00");

                                        dt_att.Rows[i][" √ŒÌ—1"] = string.Format("{0:hh\\:mm}", Late);
                                        if (dt_att.Rows[i][" √ŒÌ—1"].ToString() == "00:00") dt_att.Rows[i][" √ŒÌ—1"] = "";
                                    }
                                }
                                #endregion

                                #region ÃÂ«“ «·Õ÷Ê—
                                myDict.TryGetValue(reportViewModel.IOs[p].DeviceNumber.ToString(), out Device_Name);
                                dt_att.Rows[i]["ÃÂ«“ «·Õ÷Ê—"] = Device_Name;
                                #endregion

                                #region Õ—ﬂ«  „⁄œ·…
                                //if (IO.Select_Cout(reportViewModel.IOs.Rows[p]["Index"].ToString()) > 0)
                                //{
                                //    dt_att.Rows[i]["Õ—ﬂ«  „⁄œ·…"] += " Õ÷Ê— œÊ«„ 1 ";
                                //}
                                #endregion
                            }

                            reportViewModel.IOs.RemoveAt(p); // Õ–› «·Õ—ﬂ…
                            p--;
                        }
                        #endregion

                        #region ≈‰’—«› œÊ«„ 1
                        else if (reportViewModel.IOs[p].Event.ToString() == "1" && m >= ds && m <= de && t(dt_att.Rows[i], 1, m) > TimeSpan.Parse("0.00:00:00")) // ≈‰’—«› œÊ«„ 1
                        {
                            if (dt_att.Rows[i]["Õ÷Ê— œÊ«„ 1"].ToString() == "") continue;
                            if (dt_att.Rows[i]["≈‰’—«› œÊ«„ 1"].ToString() != "" && ignore_l1 == true) continue;

                            string s = (Convert.ToDateTime(reportViewModel.IOs[p].TTime).ToString(sd) == y) ? sh : l;
                            dt_att.Rows[i]["≈‰’—«› œÊ«„ 1"] = Convert.ToDateTime(reportViewModel.IOs[p].TTime).ToString(s);

                            ignore_l1 = Convert.ToBoolean(reportViewModel.IOs[p].Priority);

                            #region  ≈‰’—«› „»ﬂ— Ê ≈÷«›Ì
                            if (Fixed(io_day, reportViewModel.Worksys) == false) // ≈–« ﬂ«‰ ‰Ÿ«„ À«» 
                            {
                                string end1 = WS_end(io_day, reportViewModel.Worksys);
                                if (m.ToString("yyyy-MM-dd") == y && com(end1, m.ToString("HH:mm")) == true) // ≈‰’—«› „»ﬂ— ø
                                {
                                    string leavearly = sub(end1, m.ToString("HH:mm"));
                                    dt_att.Rows[i]["≈‰’—«› „»ﬂ—"] = leavearly;
                                }
                                else
                                {
                                    dt_att.Rows[i]["≈‰’—«› „»ﬂ—"] = "";
                                    TimeSpan end = WS_End(Convert.ToDateTime(dt_att.Rows[i]["«· «—ÌŒ"]).ToString("dddd"), reportViewModel.Worksys);
                                    TimeSpan leave = Convert.ToDateTime(dt_att.Rows[i]["≈‰’—«› œÊ«„ 1"]).TimeOfDay;
                                    if (m.ToString("yyyy-MM-dd") != y) leave += TimeSpan.Parse("1.00:00:00"); // ≈–« ﬂ«‰ «·«‰’—«› ›Ì «·ÌÊ„ «· «·Ì

                                    TimeSpan result = (leave > end) ? (leave - end) : TimeSpan.Parse("0.00:00:00");
                                    string sresult = string.Format("{0:hh\\:mm}", result);

                                    dt_att.Rows[i]["≈÷«›Ì"] = string.Format("{0:hh\\:mm}", sum(dt_att.Rows[i]["≈÷«›Ì"].ToString(), sresult));
                                    if (dt_att.Rows[i]["≈÷«›Ì"].ToString() == "00:00") dt_att.Rows[i]["≈÷«›Ì"] = "";
                                }
                            }
                            #endregion

                            #region ÃÂ«“ «·≈‰’—«›
                            myDict.TryGetValue(reportViewModel.IOs[p].DeviceNumber.ToString(), out Device_Name);
                            dt_att.Rows[i]["ÃÂ«“ «·≈‰’—«›"] = Device_Name;
                            #endregion

                            #region Õ—ﬂ«  „⁄œ·…
                            //if (IO.Select_Cout(reportViewModel.IOs.Rows[p]["Index"].ToString()) > 0)
                            //{
                            //    dt_att.Rows[i]["Õ—ﬂ«  „⁄œ·…"] += " ≈‰’—«› œÊ«„ 1 ";
                            //}
                            #endregion

                            reportViewModel.IOs.RemoveAt(p);
                            p--;
                        }
                        #endregion

                        #region Õ÷Ê— œÊ«„ 2
                        else if (reportViewModel.IOs[p].Event.ToString() == "2" && x == y) // Õ÷Ê— œÊ«„ 2
                        {
                            string s = (Convert.ToDateTime(reportViewModel.IOs[p].TTime).ToString(sd) == y) ? sh : l;
                            dt_att.Rows[i]["Õ÷Ê— œÊ«„ 2"] = (dt_att.Rows[i]["Õ÷Ê— œÊ«„ 2"].ToString() == "") ? Convert.ToDateTime(reportViewModel.IOs[p].TTime).ToString(s) : dt_att.Rows[i]["Õ÷Ê— œÊ«„ 2"].ToString();

                            #region Õ÷Ê— „»ﬂ— Ê  √ŒÌ—
                            string start2 = WS_start2(io_day, reportViewModel.Worksys);
                            if (com(start2, m.ToString("HH:mm")) == true)
                            {
                                string attearly = sub(start2, m.ToString("HH:mm"));
                                dt_att.Rows[i]["Õ÷Ê— „»ﬂ—"] = attearly; // ÌÊÃœ Õ÷Ê— „»ﬂ—

                                dt_att.Rows[i]["Õ÷Ê— „»ﬂ—"] = sum(dt_att.Rows[i]["Õ÷Ê— „»ﬂ—"].ToString(), attearly);
                            }
                            else
                            {
                                //if (reportViewModel.Worksys.Rows[0]["LateCheck"].ToString() == "True")
                                //{
                                TimeSpan start = WS_Start2(Convert.ToDateTime(dt_att.Rows[i]["«· «—ÌŒ"]).ToString("dddd"), reportViewModel.Worksys);
                                TimeSpan att = Convert.ToDateTime(dt_att.Rows[i]["Õ÷Ê— œÊ«„ 2"]).TimeOfDay;

                                TimeSpan Late = (att > start) ? (att - start) : TimeSpan.Parse("0.00:00:00");


                                dt_att.Rows[i][" √ŒÌ—2"] = string.Format("{0:hh\\:mm}", Late);
                                if (dt_att.Rows[i][" √ŒÌ—2"].ToString() == "00:00") dt_att.Rows[i][" √ŒÌ—2"] = "";
                                //}
                            }
                            #endregion

                            #region Õ—ﬂ«  „⁄œ·…
                            //if (IO.Select_Cout(reportViewModel.IOs.Rows[p]["Index"].ToString()) > 0)
                            //{
                            //    dt_att.Rows[i]["Õ—ﬂ«  „⁄œ·…"] += " Õ÷Ê— œÊ«„ 2 ";
                            //}
                            #endregion

                            reportViewModel.IOs.RemoveAt(p);
                            p--;
                        }
                        #endregion

                        #region ≈‰’—«› œÊ«„ 2
                        else if (reportViewModel.IOs[p].Event.ToString() == "3" && m >= ds && m <= de && t(dt_att.Rows[i], 2, m) > TimeSpan.Parse("0.00:00:00")) // ≈‰’—«› œÊ«„ 2
                        {
                            if (dt_att.Rows[i]["Õ÷Ê— œÊ«„ 2"].ToString() == "") continue;
                            if (dt_att.Rows[i]["≈‰’—«› œÊ«„ 2"].ToString() != "" && ignore_l2 == true) continue;

                            string s = (Convert.ToDateTime(reportViewModel.IOs[p].TTime).ToString(sd) == y) ? sh : l;
                            dt_att.Rows[i]["≈‰’—«› œÊ«„ 2"] = Convert.ToDateTime(reportViewModel.IOs[p].TTime).ToString(s);

                            ignore_l2 = Convert.ToBoolean(reportViewModel.IOs[p].Priority);

                            #region ≈‰’—«› „»ﬂ— Ê ≈÷«›Ì
                            string end2 = WS_end2(io_day, reportViewModel.Worksys);
                            if (m.ToString("yyyy-MM-dd") == y && com(end2, m.ToString("HH:mm")) == true) // ≈‰’—«› „»ﬂ—
                            {
                                string leavearly = sum(dt_att.Rows[i]["≈‰’—«› „»ﬂ—"].ToString(), sub(end2, m.ToString("HH:mm")));
                                dt_att.Rows[i]["≈‰’—«› „»ﬂ—"] = leavearly;
                            }
                            else
                            {
                                if (reportViewModel.Worksys.BonusCheck.ToString() == "True") // ≈÷«›Ì
                                {
                                    TimeSpan end = WS_End2(Convert.ToDateTime(dt_att.Rows[i]["«· «—ÌŒ"]).ToString("dddd"), reportViewModel.Worksys);
                                    TimeSpan leave = Convert.ToDateTime(dt_att.Rows[i]["≈‰’—«› œÊ«„ 2"]).TimeOfDay;
                                    if (m.ToString("yyyy-MM-dd") != y) leave += TimeSpan.Parse("1.00:00:00"); // ≈–« ﬂ«‰ «·«‰’—«› ›Ì «·ÌÊ„ «· «·Ì

                                    TimeSpan result = (leave > end) ? (leave - end) : TimeSpan.Parse("0.00:00:00");
                                    string sresult = string.Format("{0:hh\\:mm}", result);

                                    dt_att.Rows[i]["≈÷«›Ì"] = string.Format("{0:hh\\:mm}", sum(dt_att.Rows[i]["≈÷«›Ì"].ToString(), sresult));
                                    if (dt_att.Rows[i]["≈÷«›Ì"].ToString() == "00:00") dt_att.Rows[i]["≈÷«›Ì"] = "";
                                }
                            }
                            #endregion

                            #region Õ—ﬂ«  „⁄œ·…
                            //if (IO.Select_Cout(reportViewModel.IOs.Rows[p]["Index"].ToString()) > 0)
                            //{
                            //    dt_att.Rows[i]["Õ—ﬂ«  „⁄œ·…"] += " ≈‰’—«› œÊ«„ 2";
                            //}
                            #endregion

                            reportViewModel.IOs.RemoveAt(p);
                            p--;
                        }
                        #endregion
                    }
                }
            }
            #endregion

            foreach (DataRow r in dt_att.Rows)
            {
                #region RowTotals

                #region Per
                if (r["Õ÷Ê— œÊ«„ 1"].ToString() != "" && r["Õ÷Ê— œÊ«„ 1"].ToString() != "H" && r["≈‰’—«› œÊ«„ 1"].ToString() != "") // «·› —… «·√Ê·Ï
                {
                    r["«·› —… «·√Ê·Ï"] = string.Format("{0:hh\\:mm}", Per(r, 1));
                }
                if (r["Õ÷Ê— œÊ«„ 2"].ToString() != "" && r["≈‰’—«› œÊ«„ 2"].ToString() != "") // «·› —… «·À«‰Ì…
                {
                    r["«·› —… «·À«‰Ì…"] = string.Format("{0:hh\\:mm}", Per(r, 2));
                }

                r["Õ÷Ê— „»ﬂ—"] = sum(r["Õ÷Ê— „»ﬂ—1"].ToString(), r["Õ÷Ê— „»ﬂ—2"].ToString());
                if (r["Õ÷Ê— „»ﬂ—"].ToString() == "00:00") r["Õ÷Ê— „»ﬂ—"] = "";
                r["≈‰’—«› „»ﬂ—"] = sum(r["≈‰’—«› „»ﬂ—1"].ToString(), r["≈‰’—«› „»ﬂ—2"].ToString());
                if (r["≈‰’—«› „»ﬂ—"].ToString() == "00:00") r["≈‰’—«› „»ﬂ—"] = "";
                r[" √ŒÌ—"] = sum(r[" √ŒÌ—1"].ToString(), r[" √ŒÌ—2"].ToString());
                if (r[" √ŒÌ—"].ToString() == "00:00") r[" √ŒÌ—"] = "";
                r["≈÷«›Ì"] = sum(r["≈÷«›Ì1"].ToString(), r["≈÷«›Ì2"].ToString());
                if (r["≈÷«›Ì"].ToString() == "00:00") r["≈÷«›Ì"] = "";

                string day = Convert.ToDateTime(r["«· «—ÌŒ"]).ToString("dddd");
                #endregion

                #region Fixed
                if (Fixed(day, reportViewModel.Worksys) == false) // Fixed?
                {
                    r["‰Ÿ«„ «·„Ê«⁄Ìœ"] = "À«» …"; // ‰Ÿ«„ «·„Ê«⁄Ìœ
                    r["«·œÊ«„"] = Per_Hours(day, reportViewModel.Worksys); // «·œÊ«„

                    #region ≈Ã„«·Ì «·„” ﬁÿ⁄
                    if (reportViewModel.Worksys.LateCheck.ToString() == "True" && reportViewModel.Worksys.LeaveEarly.ToString() == "False") //   √ŒÌ— ›ﬁÿ
                    {
                        r["≈Ã„«·Ì «·„” ﬁÿ⁄"] = r[" √ŒÌ—"].ToString();
                    }
                    else if (reportViewModel.Worksys.LateCheck.ToString() == "False" && reportViewModel.Worksys.LeaveEarly.ToString() == "True") //  ≈‰’—«› „»ﬂ— ›ﬁÿ
                    {
                        r["≈Ã„«·Ì «·„” ﬁÿ⁄"] = r["≈‰’—«› „»ﬂ—"].ToString();
                    }
                    else if (reportViewModel.Worksys.LateCheck.ToString() == "True" && reportViewModel.Worksys.LeaveEarly.ToString() == "True") //    √ŒÌ— Ê≈‰’—«› „»ﬂ—
                    {
                        r["≈Ã„«·Ì «·„” ﬁÿ⁄"] = sum(r[" √ŒÌ—"].ToString(), r["≈‰’—«› „»ﬂ—"].ToString());
                    }
                    else // ·«  √ŒÌ— Ê·« ≈‰’—«› „»ﬂ—
                    {
                        r["≈Ã„«·Ì «·„” ﬁÿ⁄"] = "";
                    }
                    if (r["≈Ã„«·Ì «·„” ﬁÿ⁄"].ToString() == "00:00") r["≈Ã„«·Ì «·„” ﬁÿ⁄"] = "";
                    #endregion

                    #region ≈Ã„«·Ì «·„÷«›
                    if (reportViewModel.Worksys.AttEarly.ToString() == "True" && reportViewModel.Worksys.BonusCheck.ToString() == "False") //  Õ÷Ê— „»ﬂ— ›ﬁÿ
                    {
                        r["≈Ã„«·Ì «·„÷«›"] = r["Õ÷Ê— „»ﬂ—"].ToString();
                    }
                    else if (reportViewModel.Worksys.AttEarly.ToString() == "False" && reportViewModel.Worksys.BonusCheck.ToString() == "True") //  ≈÷«›Ì ›ﬁÿ
                    {
                        r["≈Ã„«·Ì «·„÷«›"] = r["≈÷«›Ì"].ToString();
                    }
                    else if (reportViewModel.Worksys.AttEarly.ToString() == "True" && reportViewModel.Worksys.BonusCheck.ToString() == "True") //   Õ÷Ê— „»ﬂ— Ê≈÷«›Ì
                    {
                        r["≈Ã„«·Ì «·„÷«›"] = sum(r["≈÷«›Ì"].ToString(), r["Õ÷Ê— „»ﬂ—"].ToString());
                    }
                    else // ·« Õ÷Ê— „»ﬂ— Ê·« ≈÷«›Ì
                    {
                        r["≈Ã„«·Ì «·„÷«›"] = "";
                    }
                    if (r["≈Ã„«·Ì «·„÷«›"].ToString() == "00:00") r["≈Ã„«·Ì «·„÷«›"] = "";
                    #endregion

                    r["⁄œœ «·”«⁄« "] = sub(sum(r["«·œÊ«„"].ToString(), r["≈Ã„«·Ì «·„÷«›"].ToString()), r["≈Ã„«·Ì «·„” ﬁÿ⁄"].ToString()); // ⁄œœ «·”«⁄« 


                    if (r["Õ÷Ê— œÊ«„ 1"].ToString() != "H" & r["Õ÷Ê— œÊ«„ 1"].ToString() != "" || r["«·› —… «·À«‰Ì…"].ToString() != "") // ≈÷«›Ì
                    {
                        if (Bonus(day, reportViewModel.Worksys) == true) // Full Bonus ?
                        {
                            r["‰Ê⁄ «·≈÷«›Ì"] = "ﬂ· «·ÌÊ„";
                            r["≈÷«›Ì"] = r["⁄œœ «·”«⁄« "];
                        }
                        else // Normal Bonus
                        {
                            r["‰Ê⁄ «·≈÷«›Ì"] = "⁄«œÌ";
                        }
                    }
                }
                #endregion

                #region Non Fixed
                if (Fixed(day, reportViewModel.Worksys) == true) // Non Fixed?
                {
                    r["‰Ÿ«„ «·„Ê«⁄Ìœ"] = "€Ì— À«» …";

                    r["«·œÊ«„"] = Per_Hours(day, reportViewModel.Worksys); // «·œÊ«„

                    if (r["Õ÷Ê— œÊ«„ 1"].ToString() != "H" & r["Õ÷Ê— œÊ«„ 1"].ToString() != "" || r["«·› —… «·À«‰Ì…"].ToString() != "") // ⁄œœ «·”«⁄« 
                    {
                        string f = (r["«·› —… «·√Ê·Ï"].ToString() != "") ? r["«·› —… «·√Ê·Ï"].ToString() : "00:00";
                        string s = (r["«·› —… «·À«‰Ì…"].ToString() != "") ? r["«·› —… «·À«‰Ì…"].ToString() : "00:00";
                        r["⁄œœ «·”«⁄« "] = sum(f, s);
                    }

                    #region «· √ŒÌ—
                    if (r["⁄œœ «·”«⁄« "].ToString() != "" || r["«·œÊ«„"].ToString() != "") //  √ŒÌ—
                    {
                        if (com(r["«·œÊ«„"].ToString(), r["⁄œœ «·”«⁄« "].ToString()) == true)
                        {
                            r[" √ŒÌ—"] = sub(r["«·œÊ«„"].ToString(), r["⁄œœ «·”«⁄« "].ToString());
                        }
                    }
                    #endregion

                    if (Bonus(day, reportViewModel.Worksys) == true) // Full Bonus ?
                    {
                        r["‰Ê⁄ «·≈÷«›Ì"] = "ﬂ· «·ÌÊ„";
                        r["≈÷«›Ì"] = r["⁄œœ «·”«⁄« "];
                    }
                    else
                    {
                        if (r["«·› —… «·√Ê·Ï"].ToString() != "" || r["«·› —… «·À«‰Ì…"].ToString() != "") // Normal Bonus
                        {
                            r["‰Ê⁄ «·≈÷«›Ì"] = "⁄«œÌ";
                            r["≈÷«›Ì"] = (com(r["⁄œœ «·”«⁄« "].ToString(), r["«·œÊ«„"].ToString())) ? sub(r["⁄œœ «·”«⁄« "].ToString(), r["«·œÊ«„"].ToString()) : "";
                        }
                    }
                }

                #endregion

                #region Holiday
                if (Holiday(day, reportViewModel.Worksys) == true) // √Ã«“… «”»Ê⁄Ì… 
                {
                    if (Bonus(day, reportViewModel.Worksys) == false) // ·Ì” ≈÷«›Ì
                    {
                        r["Õ÷Ê— œÊ«„ 1"] = "";
                        r["Õ÷Ê— „»ﬂ—1"] = "";
                        r[" √ŒÌ—1"] = "";

                        r["≈‰’—«› œÊ«„ 1"] = "";
                        r["≈‰’—«› „»ﬂ—1"] = "";
                        r["≈÷«›Ì1"] = "";

                        r["«·› —… «·√Ê·Ï"] = "";

                        r["Õ÷Ê— œÊ«„ 2"] = "";
                        r["Õ÷Ê— „»ﬂ—2"] = "";
                        r[" √ŒÌ—2"] = "";

                        r["≈‰’—«› œÊ«„ 2"] = "";
                        r["≈‰’—«› „»ﬂ—2"] = "";
                        r[" √ŒÌ—2"] = "";

                        r["«·› —… «·À«‰Ì…"] = "";

                        r["Õ÷Ê— „»ﬂ—"] = "";
                        r["≈‰’—«› „»ﬂ—"] = "";

                        r[" √ŒÌ—"] = "";
                        r["≈÷«›Ì"] = "";

                        r["«·œÊ«„"] = "";

                        r["≈Ã„«·Ì «·„” ﬁÿ⁄"] = "";
                        r["≈Ã„«·Ì «·„÷«›"] = "";

                        r["⁄œœ «·”«⁄« "] = "";
                        r["‰Ÿ«„ «·„Ê«⁄Ìœ"] = "";
                        r["‰Ê⁄ «·≈÷«›Ì"] = "";
                        r["√Ã«“… ø"] = "√Ã«“…";
                        r["⁄œœ «·”«⁄« "] = "";
                        r["ÃÂ«“ «·Õ÷Ê—"] = "";
                        r["ÃÂ«“ «·≈‰’—«›"] = "";
                        r["€«∆» ø"] = "";
                        r["Õ—ﬂ«  „⁄œ·…"] = "";
                    }
                    else // ≈÷«›Ì
                    {
                        r["√Ã«“… ø"] = "√Ã«“…";
                    }
                }
                #endregion

                #region Abset
                if (r["√Ã«“… ø"].ToString() == "" && r["Õ÷Ê— œÊ«„ 1"].ToString() == "" && r["≈‰’—«› œÊ«„ 1"].ToString() == "" && r["Õ÷Ê— œÊ«„ 2"].ToString() == "" && r["≈‰’—«› œÊ«„ 2"].ToString() == "") // €«∆»
                {
                    r["€«∆» ø"] = "€«∆»";
                }
                #endregion

                #endregion
            }

            #region ColumnsTotals
            string AttEarly1 = "00:00";
            string Late1 = "00:00";
            string LeaveEarly1 = "00:00";
            string Bonus1 = "00:00";
            string Per1 = "00:00";
            string AttEarly2 = "00:00";
            string Late2 = "00:00";
            string LeaveEarly2 = "00:00";
            string Bonus2 = "00:00";
            string Per2 = "00:00";
            string come_early = "00:00";
            string leave_early = "00:00";
            string total_late = "00:00";
            string total_over = "00:00";
            string total_per = "00:00";
            string TotalSub = "00:00";
            string TotalSum = "00:00";
            string total_hours = "00:00";
            int holiday = 0;
            int absent = 0;
            int edited = 0;
            foreach (DataRow r in dt_att.Rows)
            {
                AttEarly1 = sum(AttEarly1, r["Õ÷Ê— „»ﬂ—1"].ToString());
                Late1 = sum(Late1, r[" √ŒÌ—1"].ToString());
                LeaveEarly1 = sum(LeaveEarly1, r["≈‰’—«› „»ﬂ—1"].ToString());
                Bonus1 = sum(Bonus1, r["≈÷«›Ì1"].ToString());
                Per1 = sum(Per1, r["«·› —… «·√Ê·Ï"].ToString());
                AttEarly2 = sum(AttEarly2, r["Õ÷Ê— „»ﬂ—2"].ToString());
                Late2 = sum(Late2, r[" √ŒÌ—2"].ToString());
                LeaveEarly2 = sum(LeaveEarly2, r["≈‰’—«› „»ﬂ—2"].ToString());
                Bonus2 = sum(Bonus2, r["≈÷«›Ì2"].ToString());
                Per2 = sum(Per2, r["«·› —… «·À«‰Ì…"].ToString());
                come_early = sum(come_early, r["Õ÷Ê— „»ﬂ—"].ToString());
                leave_early = sum(leave_early, r["≈‰’—«› „»ﬂ—"].ToString());
                total_late = sum(total_late, r[" √ŒÌ—"].ToString());
                total_over = sum(total_over, r["≈÷«›Ì"].ToString());
                total_per = sum(total_per, r["«·œÊ«„"].ToString());
                TotalSub = sum(TotalSub, r["≈Ã„«·Ì «·„” ﬁÿ⁄"].ToString());
                TotalSum = sum(TotalSum, r["≈Ã„«·Ì «·„÷«›"].ToString());
                total_hours = sum(total_hours, r["⁄œœ «·”«⁄« "].ToString());
                if (r["√Ã«“… ø"].ToString() == "√Ã«“…") holiday++;
                if (r["€«∆» ø"].ToString() == "€«∆»") absent++;
                if (r["Õ—ﬂ«  „⁄œ·…"].ToString().Length > 0 && r["Õ—ﬂ«  „⁄œ·…"].ToString().Length <= 13)
                {
                    edited++;
                }
                else if (r["Õ—ﬂ«  „⁄œ·…"].ToString().Length > 13 && r["Õ—ﬂ«  „⁄œ·…"].ToString().Length <= 26)
                {
                    edited = edited + 2;
                }
                else if (r["Õ—ﬂ«  „⁄œ·…"].ToString().Length > 26 && r["Õ—ﬂ«  „⁄œ·…"].ToString().Length <= 39)
                {
                    edited = edited + 3;
                }
                else if (r["Õ—ﬂ«  „⁄œ·…"].ToString().Length > 39 && r["Õ—ﬂ«  „⁄œ·…"].ToString().Length <= 52)
                {
                    edited = edited + 4;
                }
            }
            dt_att.Rows.Add(
                "≈Ã„«·Ì", // «· «—ÌŒ
                null, // «·ÌÊ„
                null, // Õ÷Ê— œÊ«„1
                AttEarly1, // Õ÷Ê— „»ﬂ—1
                Late1, //  √ŒÌ—1
                null, // ≈‰’—«› œÊ«„1
                LeaveEarly1, // ≈‰’—«› „»ﬂ—1
                Bonus1, // ≈÷«›Ì1
                Per1, // «·› —… «·√Ê·
                null, // Õ÷Ê— œÊ«„2
                AttEarly2, // Õ÷Ê— „»ﬂ—2
                Late2, //  √ŒÌ—2
                null, // ≈‰’—«› œÊ«„2
                LeaveEarly2, // ≈‰’—«› „»ﬂ—2
                Bonus2, // ≈÷«›Ì2
                Per2, // «·› —… «·À«‰Ì…
                come_early, // Õ÷Ê— „»ﬂ—
                total_late, //  √ŒÌ—
                leave_early, // ≈‰’—«› „»ﬂ—
                total_over, // ≈÷«›Ì
                total_per, // «·œÊ«„
                TotalSub, // ≈Ã„«·Ì «·„” ﬁÿ⁄
                TotalSum, // ≈Ã„«·Ì «·„÷«›
                total_hours, // ⁄œœ«·”«⁄« 
                holiday.ToString(),
                absent.ToString(),
                null,
                null,
                null,
                null,
                edited.ToString()
                );

            #endregion

            List<AttendanceReportViewModel> attendanceReportViewModels = new List<AttendanceReportViewModel>();
            foreach (DataRow row in dt_att.Rows)
            {
                attendanceReportViewModels.Add(new AttendanceReportViewModel
                {
                    Date = row[0].ToString(),
                    Day = row[1].ToString(),

                    Attend1 = row[2].ToString(),
                    EarlyAttend1 = row[3].ToString(),
                    Late1 = row[4].ToString(),
                    Depart1 = row[5].ToString(),
                    EarlyDepart1 = row[6].ToString(),
                    Bonus1 = row[7].ToString(),
                    Shift1 = row[8].ToString(),

                    Attend2 = row[9].ToString(),
                    EarlyAttend2 = row[10].ToString(),
                    Late2 = row[11].ToString(),
                    Depart2 = row[12].ToString(),
                    EarlyDepart2 = row[13].ToString(),
                    Bonus2 = row[14].ToString(),
                    Shift2 = row[15].ToString(),

                    Early = row[16].ToString(),
                    Late = row[17].ToString(),
                    EarlyDepart = row[18].ToString(),
                    Bonus = row[19].ToString(),

                    TotalTime = row[20].ToString(),
                    TotalSubtract = row[21].ToString(),
                    TotalSupplement = row[22].ToString(),

                    TotalHours = row[23].ToString(),
                    Holiday = row[24].ToString(),
                    Absent = row[25].ToString(),
                    AttendDevice = row[26].ToString(),
                    DepartDevice = row[27].ToString(),
                    Worksys = row[28].ToString(),
                    BonusType = row[29].ToString(),
                    UpdatedActions = row[30].ToString()
                    });
            }
            return attendanceReportViewModels;
        }

        public async Task<ReportGetViewModel> GetReportGetViewModel()
        {
            ReportGetViewModel reportGetViewModel = new ReportGetViewModel();
            var response = await httpService.Get<ReportGetViewModel>(url);

            if (!response.Success)
            {
                reportGetViewModel.Exception = await response.GetBody();
            }
            else
            {
                reportGetViewModel = response.Response;
            }
            return reportGetViewModel;
        }
    }
}
