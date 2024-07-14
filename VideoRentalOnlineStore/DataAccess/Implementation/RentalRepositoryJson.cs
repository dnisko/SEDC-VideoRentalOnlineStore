using DataAccess.Interfaces;
using DomainModels;

namespace DataAccess.Implementation
{
    public class RentalRepositoryJson : RepositoryJson<Rental>, IRentalRepository
    {
        public List<Rental> GetAllRentedMovies()
        {
            var rentedMovies = ReadContent();
            return rentedMovies;
        }

        public Rental GetActiveRental(int userId, int movieId)
        {
            var activeRentals = ReadContent();
            return activeRentals.FirstOrDefault(x => x.UserId == userId && x.MovieId == movieId);
        }
    }
}
