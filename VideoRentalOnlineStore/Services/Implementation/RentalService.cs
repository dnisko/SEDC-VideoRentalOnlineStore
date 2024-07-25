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
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRentalRepository _rentalRepository;
        
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
            if (movie != null && movie.Quantity > 0)
            {
                var rental = new Rental
                {
                    MovieId = movieId,
                    UserId = userId,
                    RentedOn = DateTime.Now
                };
                _rentalRepository.Save(rental);
                _movieRepository.DecreaseQuantity(movieId);
            }
        }

        public void ReturnMovie(int rentalId)
        {
            var rental = _rentalRepository.GetById(rentalId);
            if (rental != null)
            {
                rental.ReturnedOn = DateTime.Now;
                _rentalRepository.Save(rental);
                _movieRepository.IncreaseQuantity(rental.MovieId);
            }
        }

        public List<RentalViewModel> GetCurrentRentedMoviesByUser(int userId)
        {
            var items = _rentalRepository.GetCurrentRentedMoviesByUser(userId);
            return items.Select(x => x.ToModel()).ToList();
        }

        public List<RentalViewModel> GetUserHistoryRent(int userId)
        {
            return _rentalRepository.GetUserHistoryRent(userId).Select(x => x.ToModel()).ToList();
        }

        public List<RentalViewModel> GetAllRentals()
        {
            return _rentalRepository.GetAllRentals().Select(x => x.ToModel()).ToList();
        }
    }
}
