using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EagleEye.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SqlDbContext.SqlDbContext _context;
        protected readonly IMapper _mapper;
        private DbSet<T> entities;
        private string ErrorMsg = string.Empty;
        public Repository(SqlDbContext.SqlDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
            entities = context.Set<T>();
        }

        public T GetById(object Id)
        {
            if (Id == null) throw new ArgumentNullException("Id");

            return entities.Find(Id);
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Add(T Entity)
        {
            if (Entity == null) throw new ArgumentNullException("Entity");

            entities.Add(Entity);
            _context.SaveChanges();
        }

        public void Delete(T Entity)
        {
            if (Entity == null) throw new ArgumentNullException("Entity");
            entities.Remove(Entity);
            _context.SaveChanges();
        }

        //public void Update(T Entity)
        //{
        //    if (Entity == null) throw new ArgumentNullException("Entity");
        //    _context.SaveChanges();
        //}

        public void Update(T EntityModel, T UpdatedEntity)
        {
            if (EntityModel == null) throw new ArgumentNullException("EntityModel");
            if (UpdatedEntity == null) throw new ArgumentNullException("UpdatedEntity");

            _mapper.Map(UpdatedEntity, EntityModel);
            _context.SaveChanges();

        }
    }
}
