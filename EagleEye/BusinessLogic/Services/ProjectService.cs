using EagleEye.DataAccess.Entities;
using EagleEye.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EagleEye.BusinessLogic.Services
{
    public class ProjectService 
    {
        private readonly IRepository<Project> _repo;
        public ProjectService(IRepository<Project> repository) { this._repo = repository; }


        public IEnumerable<Project> GetAllProjects => _repo.GetAll();
    }
}
