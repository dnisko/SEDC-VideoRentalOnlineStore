using ViewModels;

namespace Services.Interfaces
{
    public interface IRentalService
    {
        List<RentalViewModel> GetAllRentedMovies();
        RentalViewModel GetDetails(int id);
        //void Save(RentalViewModel rent);
        //void Delete(int id);
        public void RentMovie(int userId, int movieId);
        public void ReturnMovie(int userId, int rentalId);
    }
}
