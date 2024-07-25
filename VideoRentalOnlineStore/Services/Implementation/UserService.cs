using DataAccess.Implementation;
using DataAccess.Interfaces;
using DomainModels;
using DomainModels.Enums;
using Mappers;
using Services.Interfaces;
using ViewModels;

namespace Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRentalRepository _rentalRepository;

        public UserService(IUserRepository userRepository, IRentalRepository rentalRepository)
        {
            _userRepository = userRepository;
            _rentalRepository = rentalRepository;
        }
        public List<UserViewModel> GetAll()
        {
            var users = _userRepository.GetAll();
            return users.Select(x => x.ToModel()).ToList();
        }

        public UserViewModel GetDetails(int id)
        {
            var user = _userRepository.GetById(id);
            return user.ToModel();
        }

        public async Task SaveAsync(UserViewModel userModel)
        {
            //if it is updating user
            if (_userRepository.GetAll().Any(x => x.UserName.ToLower() == userModel.UserName.ToLower() && x.Id != userModel.Id))
            {
                throw new Exception("Username is taken.");
            }

            //if it is new user
            //if (_userRepository.GetAll().Any(x => x.UserName.ToLower() == userModel.UserName.ToLower()))
            //{
            //    throw new Exception("Username is taken.");
            //}

            User user;

            // Check if the user already exists
            if (userModel.Id > 0)
            {
                // Fetch the existing user
                user = _userRepository.GetAll().FirstOrDefault(x => x.Id == userModel.Id);
                if (user == null)
                {
                    throw new Exception("User not found.");
                }

                // Update existing user properties
                user.FullName = userModel.FullName;
                user.Age = userModel.Age;
                user.UserName = userModel.UserName;
                user.Password = userModel.Password;
                user.Email = userModel.Email;
                user.CreatedOn = userModel.CreatedOn;
                user.IsSubscriptionExpired = userModel.IsSubscriptionExpired;
                user.SubscriptionType = userModel.SubscriptionType;
            }
            else
            {
                // Create a new user
                user = new User
                {
                    FullName = userModel.FullName,
                    Age = userModel.Age,
                    UserName = userModel.UserName,
                    Password = userModel.Password,
                    Email = userModel.Email,
                    CreatedOn = userModel.CreatedOn,
                    IsSubscriptionExpired = userModel.IsSubscriptionExpired,
                    SubscriptionType = userModel.SubscriptionType
                };

                // Add the user to the repository
                _userRepository.Save(user);

                // Set the CardNumber after the user has been saved and ID has been assigned
                user.CardNumber = user.Id.ToString().PadLeft(10, '0');
                _userRepository.Save(user); // Ensure this updates the user with the new card number
            }
        }

        //public void Create(UserViewModel user)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(UserViewModel user)
        //{
        //    throw new NotImplementedException();
        //}

        public void Delete(int id)
        {
            _userRepository.DeleteById(id);
        }

        public List<UserViewModel> SearchByName(string name)
        {
            var users = _userRepository.SearchByName(name);
            return users.Select(x => x.ToModel()).ToList();
        }

        public List<UserViewModel> SearchByUserName(string userName)
        {
            var users = _userRepository.SearchByUserName(userName);
            return users.Select(x => x.ToModel()).ToList();
        }

        public UserViewModel GetCardNumber(string cardNumber)
        {
            var user = _userRepository.GetCardNumber(cardNumber);
            return user.ToModel();
        }

        public UserViewModel GetEmail(string email)
        {
            var user = _userRepository.GetEmail(email);
            return user.ToModel();
        }

        public void RegisterUser(UserViewModel newUser)
        {
            if (_userRepository.GetAll().Any(x => x.UserName.ToLower() == newUser.UserName.ToLower()
                                                  || x.Email == newUser.Email
                                                  || x.CardNumber == newUser.CardNumber))
            {
                throw new Exception("The username, email or CardNumber is taken.");
            }

            var user = new User
            {
                Id = newUser.Id,
                FullName = newUser.FullName,
                Age = newUser.Age,
                UserName = newUser.UserName,
                Password = newUser.Password,
                CardNumber = newUser.CardNumber,
                Email = newUser.Email,
                CreatedOn = DateTime.UtcNow,
                IsSubscriptionExpired = true,
                SubscriptionType = SubscriptionType.None
            };

            _userRepository.Save(user);
        }

        public List<RentalViewModel> GetCurrentRentals(int userId)
        {
            var items = _rentalRepository.GetCurrentRentedMoviesByUser(userId);
            return items.Select(x => x.ToModel()).ToList();
        }

        public List<RentalViewModel> GetRentalHistory(int userId)
        {
            var items = _rentalRepository.GetUserHistoryRent(userId);
            return items.Select(x => x.ToModel()).ToList();
        }

        public void ReturnMovie(int rentalId)
        {
            var rental = _rentalRepository.GetById(rentalId);
            if (rental != null)
            {
                rental.ReturnedOn = DateTime.Now;
                _rentalRepository.Save(rental);
            }
        }
    }
}
