using Microsoft.EntityFrameworkCore;
using pro_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pro_API.Repositories;
using pro_Models.Models;
using pro_Models.ViewModels;
using AutoMapper;

namespace pro_API.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;

        public ReportRepository(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }
        public async Task<ReportViewModel> GetReportViewModel(ReportViewModel reportViewModel)
        {
            Employee emp = await appDbContext.Employees.FirstOrDefaultAsync(x => x.Id == reportViewModel.Employee.Id);
            reportViewModel.Employee = emp;

            reportViewModel.IOs = await appDbContext.IOs.Where
                (x => x.EmpNumber == reportViewModel.Employee.Number
                && x.TTime >= reportViewModel.FromDate
                && x.TTime <= reportViewModel.ToDate).ToListAsync();

            return reportViewModel;
        }
    }
}
