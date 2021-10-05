using AutoMapper;
using EagleEye.DataAccess.Entities;
using EagleEye.DataAccess.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EagleEye.DataAccess.Repository.Repos.ProjectRepo
{
    public class ProjectRepo : Repository<Project>, IProjectRepo
    {
        public ProjectRepo(SqlDbContext.SqlDbContext context , IMapper mapper) : base(context, mapper) { }

        public IEnumerable<Project> FilterProjects(string budgetFrom, string budgetTo, string cityId, string areaId, string statusCode, string startDate, string endDate)
        {
            string query = "SELECT * FROM PROJECTS where ";
            bool budgetFromEmpty = string.IsNullOrEmpty(budgetFrom);
            bool budgetToEmpty = string.IsNullOrEmpty(budgetTo);
            bool startDateEmpty = string.IsNullOrEmpty(startDate);
            bool endDateEmpty = string.IsNullOrEmpty(endDate);

            List<string> clauses = new List<string>();
            #region Budget Clause
            if (!budgetFromEmpty &&  !budgetToEmpty)
                clauses.Add( $" Budget BETWEEN {budgetFrom} AND {budgetTo} ");

            if (!budgetFromEmpty && budgetToEmpty)
            {
                clauses.Add($" Budget >= {budgetFrom} ");
            }

            if (budgetFromEmpty && !budgetToEmpty)
            {
                clauses.Add($" Budget <= {budgetTo} ");
            }
            #endregion

            if (!string.IsNullOrEmpty(cityId)) clauses.Add($" CityId = {cityId} ");

            if (!string.IsNullOrEmpty(areaId)) clauses.Add($" AreaId = {areaId} ");

            if (!string.IsNullOrEmpty(statusCode)) clauses.Add($" StatusId = {statusCode} ");

            if (!startDateEmpty && !endDateEmpty)
            clauses.Add($" StartDate >= '{DateTime.Parse(startDate).ToString("yyyy-MM-dd")}' AND EndDate <= '{DateTime.Parse(endDate).ToString("yyyy-MM-dd")}' ");

            if (!startDateEmpty && endDateEmpty) clauses.Add($" StartDate >= '{DateTime.Parse(startDate).ToString("yyyy-MM-dd")}' ");


            if (startDateEmpty && !endDateEmpty) clauses.Add($" EndDate <= '{DateTime.Parse(endDate).ToString("yyyy-MM-dd")}'");

            query += ConcatQuery(clauses);

            List<Project> projects = _context.Projects.FromSqlRaw(query).ToList();
            return projects;
        }

        public IEnumerable<Project> GetProjectsByAdminId(int adminId)
        {
            if (adminId == 0) throw new ArgumentException("adminId = 0");

            return _context.Projects.Where(p => p.AdminstratorId == adminId).ToList();
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

        public string ConcatQuery(List<string> clauses)
        {
            string whereClause = string.Empty;

            for (int i = 0; i < clauses.Count; i++)
            {
                whereClause+=(clauses[i]);

                if (i != clauses.Count-1) whereClause+=(" AND ");
               
            }

            return whereClause;
        }
    }
}
