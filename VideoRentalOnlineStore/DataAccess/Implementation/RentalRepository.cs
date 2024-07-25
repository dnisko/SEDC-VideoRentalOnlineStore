using DataAccess.Interfaces;
using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementation
{
    public class RentalRepository : Repository<Rental>, IRentalRepository
    {
        public RentalRepository(MovieRentalAppDbContext dbContext) : base(dbContext)
        {
        }

        public List<Rental> GetAllRentedMovies()
        {
            var items = _dbContext.Rentals
                .Include(x => x.User)
                .Include(x => x.Movie)
                .ToList();
            return items;
        }

        public List<Rental> GetCurrentRentedMoviesByUser(int userId)
        {
            var items = _dbContext.Rentals
                .Where(x => x.UserId == userId && x.ReturnedOn == null)
                .Include(x => x.Movie)
                .ToList();
            return items;
        }

        public List<Rental> GetUserHistoryRent(int userId)
        {
            var items = _dbContext.Rentals
                .Where(x => x.UserId == userId)
                .Include(x => x.Movie)
                .ToList();
            return items;
        }

        public List<Rental> GetAllRentals()
        {
            var items = _dbContext.Rentals
                .Include(x => x.User)
                .Include(x => x.Movie)
                .ToList();
            return items;
        }
    }
}
