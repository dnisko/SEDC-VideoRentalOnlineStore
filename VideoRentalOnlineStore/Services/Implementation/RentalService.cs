using DataAccess.Implementation;
using DataAccess.Interfaces;
using DomainModels;
using Mappers;
using Services.Interfaces;
using ViewModels;

namespace Services.Implementation
{
    public class RentalService : IRentalService
    {
        private IMovieRepository _movieRepository;
        private IUserRepository _userRepository;
        private IRentalRepository _rentalRepository;

        public RentalService(IMovieRepository movieRepository, IUserRepository userRepository, IRentalRepository rentalRepository)
        {
            _movieRepository = movieRepository;
            _userRepository = userRepository;
            _rentalRepository = rentalRepository;
        }

        public List<RentalViewModel> GetAllRentedMovies()
        {
            var rentedMovies = _rentalRepository.GetAllRentedMovies();
            return rentedMovies.Select(x => x.ToModel()).ToList();
        }

        public RentalViewModel GetDetails(int id)
        {
            var rented = _rentalRepository.GetById(id);
            return rented.ToModel();
        }

        public void RentMovie(int userId, int movieId)
        {
            var movie = _movieRepository.GetById(movieId);

            if (movie == null || movie.Quantity < 0)
            {
                throw new Exception("The movie is not available for rent.");
            }

            var isAvailableForRent = _rentalRepository.GetActiveRental(userId, movieId);
            if (isAvailableForRent != null)
            {
                throw new Exception("The movie is already rented by you. Please return it.");
            }

            //var renting = isAvailableForRent.FirstOrDefault(x => x.ToModel());
            var rent = new Rental
            {
                UserId = userId,
                MovieId = movieId,
                RentedOn = DateTime.UtcNow
            };

            _rentalRepository.Save(rent);

            movie.Quantity--;
            _movieRepository.Save(movie);
        }

        public void ReturnMovie(int userId, int rentalId)
        {
            var rental = _rentalRepository.GetById(rentalId);

            if (rental == null || rental.UserId != userId || rental.ReturnedOn != null)
            {
                throw new Exception("Invalid rental or movie is already rented.");
            }

            rental.ReturnedOn = DateTime.UtcNow;
            _rentalRepository.Save(rental);

            var movie = _movieRepository.GetById(rental.MovieId);
            movie.Quantity++;
            _movieRepository.Save(movie);
        }
    }
}
