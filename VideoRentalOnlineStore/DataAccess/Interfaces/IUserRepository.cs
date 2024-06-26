using DomainModels;

namespace DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        List<User> SearchByName(string name);
        List<User> SearchByUserName(string userName);
        User GetCardNumber(string cardNumber);
        User GetEmail(string email);
    }
}
