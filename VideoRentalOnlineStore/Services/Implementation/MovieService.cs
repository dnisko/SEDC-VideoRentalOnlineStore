using DataAccess.Implementation;
using DomainModels;
using DomainModels.Enums;
using Mappers;
using Services.Interfaces;
using ViewModels;

namespace Services.Implementation
{
    public class MovieService : IMovieService
    {
        private MovieRepository _movieRepository;

        public MovieService()
        {
            _movieRepository = new MovieRepository();
        }

        public List<MovieViewModel> GetMovies()
        {
            var movies = _movieRepository.GetAll();
            return movies.Select(x => x.ToModel()).ToList();
        }

        public MovieViewModel GetDetails(int id)
        {
            var movie = _movieRepository.GetById(id);
            return movie.ToModel();
        }

        public void Save(MovieViewModel movieModel)
        {
            if (_movieRepository.GetAll().Any(x => 
                    x.Title.ToLower() == movieModel.Title.ToLower() 
                    && x.Language == movieModel.Language //maybe there is the same movie title, different language :)
                    && x.ReleaseDate == movieModel.ReleaseDate //and same movie title, different year
                    && x.Id != movieModel.Id))
            {
                throw new Exception("Movie is already in the database.");
            }

            var movie = new Movie()
            {
                //can we use the mapper here!?
                //userModel.ToModel();
                Id = movieModel.Id,
                Title = movieModel.Title,
                Genre = movieModel.Genre,
                Language = movieModel.Language,
                IsAvailable = movieModel.IsAvailable,
                ReleaseDate = movieModel.ReleaseDate,
                Length = movieModel.Length,
                AgeRestriction = movieModel.AgeRestriction,
                Quantity = movieModel.Quantity
            };

            _movieRepository.Save(movie);
        }

        public void Delete(int id)
        {
            _movieRepository.DeleteById(id);
        }

        public List<MovieViewModel> SearchByTitle(string title)
        {
            var movies = _movieRepository.SearchByTitle(title);
            return movies.Select(x => x.ToModel()).ToList();
        }

        public List<MovieViewModel> SearchByGenre(Genre genre)
        {
            var movies = _movieRepository.SearchByGenre(genre);
            return movies.Select(x => x.ToModel()).ToList();
        }

        public List<MovieViewModel> GetAvailableMovies()
        {
            var movies = _movieRepository.GetAvailableMovies();
            return movies.Select(x => x.ToModel()).ToList();
        }
    }
}
