using DomainModels.Enums;
using ViewModels;

namespace Services.Interfaces
{
    public interface IMovieService
    {
        List<MovieViewModel> GetMovies();
        MovieViewModel GetDetails(int id);
        void Save(MovieViewModel movie);
        void Delete(int id);
        List<MovieViewModel> SearchByTitle(string title);
        List<MovieViewModel> SearchByGenre(Genre genre);
        List<MovieViewModel> GetAvailableMovies();

    }
}
