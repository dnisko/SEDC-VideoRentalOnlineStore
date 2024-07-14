using DataAccess.Interfaces;
using DomainModels;
using DomainModels.Enums;
using System.Xml.Linq;

namespace DataAccess.Implementation
{
    internal class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieRentalAppDbContext dbContext) : base(dbContext)
        {
        }

        public List<Movie> SearchByTitle(string title)
        {
            var items = _dbContext.Movies
                .Where(x => x.Title.Contains(title))
                .ToList();
            return items;
        }

        public List<Movie> SearchByGenre(Genre genre)
        {
            var items = _dbContext.Movies
                .Where(x => x.Genre == genre)
                .ToList();
            return items;

        }

        public List<Movie> GetAvailableMovies()
        {
            var items = _dbContext.Movies
                .Where(x => x.IsAvailable == true)
                .ToList();
            return items;
        }
    }
}
