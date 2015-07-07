using Cinema.Core.Entities;
using Cinema.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected CinemaDbContext _context;
        public BaseRepository(CinemaDbContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }        
        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }


        public List<TEntity> GetBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> where)
        {
            return _context.Set<TEntity>().Where(where).ToList();
        }
    }
}
