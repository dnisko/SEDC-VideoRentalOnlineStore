using DataAccess.Interfaces;
using DomainModels;

namespace DataAccess.Implementation
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public List<User> SearchByName(string name)
        {
            var names = ReadContent();
            return names.Where(x => x.FullName.Contains(name, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        public List<User> SearchByUserName(string userName)
        {
            var users = ReadContent();
            return users.Where(x => x.UserName.Contains(userName, StringComparison.InvariantCultureIgnoreCase)).ToList();  
        }

        public User GetCardNumber(string cardNumber)
        {
            var user = ReadContent();
            return user.FirstOrDefault(x => x.CardNumber == cardNumber);
        }

        public User GetEmail(string email)
        {
            var user = ReadContent();
            return user.FirstOrDefault(x => x.Email == email);
        }
    }
}
