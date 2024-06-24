using ViewModels;

namespace Services.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> GetAll();
        UserViewModel GetDetails(int id);
        void Save(UserViewModel user);
        //void Create(UserViewModel user);
        //void Update(UserViewModel user);
        void Delete(int id);
        List<UserViewModel> SearchByName(string name);
        List<UserViewModel> SearchByUserName(string userName);
    }
}
