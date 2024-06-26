using DomainModels;

namespace DataAccess.Interfaces
{
    public interface IRentalRepository : IRepository<Rental>
    {
        //Rental GetById(int id);
        List<Rental> GetAllRentedMovies();
        Rental GetActiveRental(int userId, int movieId);
    }
}
