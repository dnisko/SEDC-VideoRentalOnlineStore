using DataAccess.Interfaces;
using DomainModels;

namespace DataAccess.Implementation
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MovieRentalAppDbContext dbContext) : base(dbContext)
        {
        }

        public List<User> SearchByName(string name)
        {
            var items = _dbContext.Users
                .Where(x => x.FullName.Contains(name))
                .ToList();
            return items;
        }

        public List<User> SearchByUserName(string userName)
        {
            var items = _dbContext.Users
                .Where(x => x.UserName.Contains(userName))
                .ToList();
            return items;
        }

        public User GetCardNumber(string cardNumber)
        {
            var cardNo = _dbContext.Users.FirstOrDefault(x => x.CardNumber == cardNumber);
            return cardNo;
        }

        public User GetEmail(string email)
        {
            var item = _dbContext.Users.FirstOrDefault(x => x.Email == email);
            return item;
        }
    }
}
