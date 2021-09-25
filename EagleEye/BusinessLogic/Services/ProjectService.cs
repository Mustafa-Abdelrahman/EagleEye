using EagleEye.DataAccess.Entities;
using EagleEye.DataAccess.Repository;
using EagleEye.DataAccess.Repository.Repos.ProjectRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EagleEye.BusinessLogic.Services
{
    public class ProjectService 
    {
        private readonly IProjectRepo _repo;
        public ProjectService(IProjectRepo repository) { this._repo = repository; }


        public List<Project> GetAllProjects => _repo.GetAll().ToList();

        public Project GetProjectById(int Id) =>  _repo.GetById(Id);
        public List<Project> GetProjectsByAdministratorId(int adminId) =>  _repo.GetProjectsByAdminId(adminId).ToList();
        public List<Project> GetProjectsByCity(int cityId) =>  _repo.GetProjectsByCity(cityId).ToList();
        public List<Project> GetProjectsByArea(int areaId) =>  _repo.GetProjectsByArea(areaId).ToList();
        public List<Project> GetProjectsByStatus(int statusValue) =>  _repo.GetProjectsByStatus(statusValue).ToList();
        public List<Project> GetProjectsByBudget(decimal from, decimal to) =>  _repo.GetProjectsByBudget(from, to).ToList();
        public void CreateProject(Project project) => _repo.Add(project);

        public void UpdateProject(Project project) => _repo.Update(project);
        public void DeleteProject(Project project) => _repo.Delete(project);

    }
}
