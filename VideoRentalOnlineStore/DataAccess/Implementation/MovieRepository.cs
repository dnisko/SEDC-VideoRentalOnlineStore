using DataAccess.Interfaces;
using DomainModels;

namespace DataAccess.Implementation
{
    public class MovieRepository : IRepository<Movie>
    {
        public List<Movie> GetAll()
        {
            return new List<Movie> { StaticDb.Movies };
        }

        public Movie GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Movie entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Movie entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Movie entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
