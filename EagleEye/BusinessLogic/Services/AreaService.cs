using EagleEye.DataAccess.Entities;
using EagleEye.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EagleEye.BusinessLogic.Services
{
    public class AreaService
    {
        private readonly IRepository<Area> _repo;

        public AreaService(IRepository<Area> repository)
        {
            this._repo = repository;
        }

        public List<Area> GetAllAreas() => _repo.GetAll().ToList();
        public Area GetAreaById(int Id) => _repo.GetById(Id);
        public void UpdateArea(Area areaModel, Area updatedArea) => _repo.Update(areaModel, updatedArea);
        public void DeleteArea(Area area) => _repo.Delete(area);
    }
}
