using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EagleEye.DataAccess.Entities;

namespace EagleEye.MappingProfiles
{
    public class EagleEyeMappingProfile : Profile
    {
        public EagleEyeMappingProfile()
        {
            CreateMap<Project, Project>();
            CreateMap<Area, Area>();
            CreateMap<City, City>();
            CreateMap<ProjectAdminstrator, ProjectAdminstrator>();
        }
    }
}
