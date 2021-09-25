using EagleEye.DataAccess.Entities;
using EagleEye.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EagleEye.BusinessLogic.Services
{
    public class ProjectAdminstratorsService
    {
        private readonly IRepository<ProjectAdminstrator> _repo;

        public ProjectAdminstratorsService(IRepository<ProjectAdminstrator> repository)
        {
            this._repo = repository;
        }

        public List<ProjectAdminstrator> GetAllAdmins() => _repo.GetAll().ToList();
        public ProjectAdminstrator GetAdminById(int Id) => _repo.GetById(Id);
        public void UpdateAdmin(ProjectAdminstrator admin) => _repo.Update(admin);
        public void DeleteAdmin(ProjectAdminstrator admin) => _repo.Delete(admin);
    }
}
