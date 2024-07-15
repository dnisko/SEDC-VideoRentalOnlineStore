using DataAccess.Interfaces;
using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseClass
    {
        protected MovieRentalAppDbContext _dbContext;

        public Repository(MovieRentalAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking().ToList();
        }

        public T GetById(int id)
        {
            var item = _dbContext.Set<T>().AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            
            if (item == null)
            {
                throw new KeyNotFoundException($"Entity with id: {id} is not found");
            }

            return item;
        }

        public void Save(T entity)
        {
            var entry = _dbContext.Entry(entity);
            if (entry.State == EntityState.Detached || entry.State == EntityState.Added)
            {
                _dbContext.Set<T>().Add(entity);
            }
            else
            {
                _dbContext.Set<T>().Update(entity);
            }
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var item = GetById(id);
            Delete(item);
        }
    }
}
