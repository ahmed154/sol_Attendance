using AutoMapper;
using pro_Models.Models;
using pro_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pro_API.MapperProfiles
{
    public class AttendanceProfile : Profile
    {
        public AttendanceProfile()
        {
            CreateMap<Depart, Depart>();
            CreateMap<Sec, Sec>();
            CreateMap<Device, Device>();
            CreateMap<Worksys, Worksys>();
        }
    }
}
