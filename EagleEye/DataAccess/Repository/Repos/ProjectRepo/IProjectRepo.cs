using EagleEye.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EagleEye.DataAccess.Repository.Repos.ProjectRepo
{
    public interface IProjectRepo : IRepository<Project>
    {
        IEnumerable<Project> GetProjectsByBudget(decimal from, decimal to);
        IEnumerable<Project> GetProjectsByAdmin(ProjectAdminstrator adminstrator);
        IEnumerable<Project> GetProjectsByCity(int cityId);
        IEnumerable<Project> GetProjectsByArea(int areaId);
        
    }
}
