using ViewModels;

namespace Services.Interfaces
{
    public interface IRentalService
    {
        List<RentalViewModel> GetAllRentedMovies();
        RentalViewModel GetDetails(int id);
        //void SaveAsync(RentalViewModel rent);
        //void Delete(int id);
        public void RentMovie(int userId, int movieId);
        public void ReturnMovie(int rentalId);
        public List<RentalViewModel> GetCurrentRentedMoviesByUser(int userId);
        public List<RentalViewModel> GetUserHistoryRent(int userId);
        public List<RentalViewModel> GetAllRentals();
    }
}
