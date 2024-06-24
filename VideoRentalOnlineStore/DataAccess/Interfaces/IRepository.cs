using DomainModels;

namespace DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseClass
    {
        List<T> GetAll();
        T GetById(int id);
        //void Add(T entity);
        //void Update(T entity);
        void Save(T entity);
        void Delete(T entity);
        void DeleteById(int id);
    }
}
