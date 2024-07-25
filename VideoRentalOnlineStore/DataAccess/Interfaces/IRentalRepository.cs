using DomainModels;

namespace DataAccess.Interfaces
{
    public interface IRentalRepository : IRepository<Rental>
    {
        //Rental GetById(int id);
        List<Rental> GetAllRentedMovies();
        List<Rental> GetCurrentRentedMoviesByUser(int userId);
        List<Rental> GetUserHistoryRent(int userId);
        List<Rental> GetAllRentals();
    }
}
