using DataAccess.Interfaces;
using DomainModels;

namespace DataAccess.Implementation
{
    public class RentalRepository : Repository<Rental>, IRentalRepository
    {
        public RentalRepository(MovieRentalAppDbContext dbContext) : base(dbContext)
        {
        }

        public List<Rental> GetAllRentedMovies()
        {
            var items = _dbContext.Rentals.ToList();
            return items;
        }

        public Rental GetActiveRental(int userId, int movieId)
        {
            var items = _dbContext.Rentals.ToList();
            return items.FirstOrDefault(x => x.MovieId == movieId && x.UserId == userId);
        }
    }
}
