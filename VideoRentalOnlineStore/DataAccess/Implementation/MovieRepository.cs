using DataAccess.Interfaces;
using DomainModels;
using DomainModels.Enums;

namespace DataAccess.Implementation
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public List<Movie> SearchByTitle(string title)
        {
            var movies = ReadContent();
            return movies.Where(x => x.Title.Contains(title, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        public List<Movie> SearchByGenre(Genre genre)
        {
            var moviesByGenre = ReadContent();
            //return moviesByGenre.Where(x => x.Genre.Equals(genre)).ToList();
            return moviesByGenre.Where(x => x.Genre == genre).ToList();
        }

        public List<Movie> GetAvailableMovies()
        {
            var availableMovies = ReadContent();
            return availableMovies.Where(x => x.IsAvailable).ToList();
        }
    }
}
