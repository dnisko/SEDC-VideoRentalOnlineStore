using DataAccess.Implementation;
using DomainModels;
using Mappers;
using Services.Interfaces;
using System.Xml.Linq;
using ViewModels;

namespace Services.Implementation
{
    public class UserService : IUserService
    {
        private UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
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

        public void Save(UserViewModel userModel)
        {
            //if it is updating user
            if (_userRepository.GetAll().Any(x => x.UserName.ToLower() == userModel.UserName.ToLower() && x.Id != userModel.Id))
            {
                throw new Exception("Username is taken.");
            }

            //if it is new user
            if (_userRepository.GetAll().Any(x => x.UserName.ToLower() == userModel.UserName.ToLower()))
            {
                throw new Exception("Username is taken.");
            }

            var user = new User()
            {
                //can we use the mapper here!?
                //userModel.ToModel();
                Id = userModel.Id,
                FullName = userModel.FullName,
                Age = userModel.Age,
                UserName = userModel.UserName,
                Password = userModel.Password,
                CardNumber = userModel.CardNumber,
                Email = userModel.Email,
                CreatedOn = userModel.CreatedOn,
                IsSubscriptionExpired = userModel.IsSubscriptionExpired,
                SubscriptionType = userModel.SubscriptionType
            };

            _userRepository.Save(user);
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
    }
}
