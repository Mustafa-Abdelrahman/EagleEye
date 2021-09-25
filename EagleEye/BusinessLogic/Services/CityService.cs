using EagleEye.DataAccess.Entities;
using EagleEye.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EagleEye.BusinessLogic.Services
{
    public class CityService
    {
        private readonly IRepository<City> _repo;

        public CityService(IRepository<City> repository)
        {
            this._repo = repository;
        }

        public List<City> GetAllCities() => _repo.GetAll().ToList();
        public City GetCityById(int Id) => _repo.GetById(Id);
        public void UpdateCity(City city) => _repo.Update(city);
        public void DeleteCity(City city) => _repo.Delete(city);
    }
}
