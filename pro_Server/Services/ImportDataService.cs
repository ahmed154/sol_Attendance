using pro_Models.Models;
using pro_Server.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace pro_Server.Services
{
    public class ImportDataService : IImportDataService
    {
        private string url = "api/ios";
        private readonly IHttpService httpService;

        public ImportDataService(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        #region Pro
        string addzeroEmpID(string s)
        {
            while (s.Length < 9)
            {
                s = "0" + s;
            }
            return s;
        }
        List<IO> IOsFromDAT(string path)
        {
            List<IO> iOs = new List<IO>();
            foreach (var line in File.ReadAllLines(path))
            {
                var record = line.Split('\t');
                iOs.Add(new IO 
                {
                    EmpNumber = record[0].Trim(),
                    TTime = Convert.ToDateTime(record[1].Trim())
                });
            }
            return iOs;
        }
        List<IO> IOsFromTXT(string path)
        {
            List<IO> iOs = new List<IO>();
            foreach (var line in File.ReadAllLines(path).Skip(1))
            {
                var record = line.Split(',');
                iOs.Add(new IO
                {
                    EmpNumber = record[1].Trim(),
                    TTime = Convert.ToDateTime(record[3].Trim()),
                    DeviceNumber = record[8].Trim()
                });
            }
            return iOs;
        }
        #endregion
        public async Task ImportData(FileStream fileStream)
        {
            FileInfo fi = new FileInfo(fileStream.Name);
            List<IO> iOs = new List<IO>();

            if (fi.Extension == ".txt")
            {
                iOs = IOsFromTXT(fileStream.Name);
            }
            else if(fi.Extension == ".dat")
            {
                iOs = IOsFromDAT(fileStream.Name);
            }

            var response = await httpService.Post<List<IO>>($"{url}", iOs);

            if (!response.Success)
            {
                //iOs[0].Exception = await response.GetBody();
            }
            else
            {
                
            }
        }
        public async Task<IEnumerable<IO>> GetAll()
        {
            List<IO> IOs = new List<IO>();
            var response = await httpService.Get<List<IO>>(url);

            string Exception;
            if (!response.Success)
            {
                 Exception = await response.GetBody();
            }
            else
            {
                IOs = response.Response;
            }
            return IOs;
        }
    }
}
