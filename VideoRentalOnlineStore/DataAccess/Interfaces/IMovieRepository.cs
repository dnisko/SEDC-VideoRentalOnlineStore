using DomainModels;
using DomainModels.Enums;

namespace DataAccess.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        List<Movie> SearchByTitle(string title);
        List<Movie> SearchByGenre(Genre genre);
        List<Movie> GetAvailableMovies();
        public void DecreaseQuantity(int movieId);
        public void IncreaseQuantity(int movieId);
    }
}
