using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using pro_Models.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace pro_API.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Depart> Departs { get; set; }
        public DbSet<Sec> Secs { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Emp> Emps { get; set; }
        public DbSet<IO> IOs { get; set; }
        public DbSet<IOEdit> IOEdits { get; set; }
        public DbSet<Worksys> Worksyss { get; set; }
    }
}
