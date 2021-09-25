using EagleEye.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EagleEye.DataAccess.Repository.Repos.ProjectRepo
{
    public class ProjectRepo : Repository<Project>, IProjectRepo
    {
        public ProjectRepo(SqlDbContext.SqlDbContext context) : base(context) { }


        public IEnumerable<Project> GetProjectsByAdmin(ProjectAdminstrator adminstrator)
        {
            if (adminstrator == null) throw new ArgumentNullException("adminstrator");

            return _context.Projects.Where(p => p.Adminstrator == adminstrator).ToList();
        }

        public IEnumerable<Project> GetProjectsByArea(int areaId)
        {
            if (areaId == 0) throw new ArgumentException("areaId = 0");

            return _context.Projects.Where(p => p.AreaId == areaId).ToList();

        }

        public IEnumerable<Project> GetProjectsByBudget(decimal fromValue, decimal toValue)
        {

            return _context.Projects.Where(p => p.Budget >= fromValue && p.Budget <= toValue).ToList();
        }

        public IEnumerable<Project> GetProjectsByCity(int cityId)
        {
            if (cityId == 0) throw new ArgumentException("cityId = 0");

            return _context.Projects.Where(p => p.CityId == cityId).ToList();

        }

        public IEnumerable<Project> GetProjectsByStatus(int statusId)
        {
            if (statusId == 0) throw new ArgumentException("statusId = 0");

            return _context.Projects.Where(p => p.CityId == statusId).ToList();
        }
    }
}
