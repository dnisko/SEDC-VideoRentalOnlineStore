using DomainModels;
using ViewModels;

namespace Services.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> GetAll();
        UserViewModel GetDetails(int id);
        Task SaveAsync(UserViewModel user);
        //void Create(UserViewModel user);
        //void Update(UserViewModel user);
        void Delete(int id);
        List<UserViewModel> SearchByName(string name);
        List<UserViewModel> SearchByUserName(string userName);
        UserViewModel GetCardNumber(string cardNumber);
        UserViewModel GetEmail(string email);
        void RegisterUser(UserViewModel newUser);
        List<RentalViewModel> GetCurrentRentals(int userId);
        List<RentalViewModel> GetRentalHistory(int userId);
        void ReturnMovie(int rentalId);
    }
}
