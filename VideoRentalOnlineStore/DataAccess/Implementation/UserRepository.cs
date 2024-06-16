using DataAccess.Interfaces;
using DomainModels;

namespace DataAccess.Implementation
{
    public class UserRepository : IRepository<User>
    {
        public List<User> GetAll()
        {
            return new List<User> { StaticDb.Users };
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
