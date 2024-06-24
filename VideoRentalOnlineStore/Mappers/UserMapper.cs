using DomainModels;
using ViewModels;

namespace Mappers
{
    public static class UserMapper
    {
        public static UserViewModel ToModel(this User user)
        {
            var model = new UserViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Age = user.Age,
                UserName = user.UserName,
                Password = user.Password,
                CardNumber = user.CardNumber,
                Email = user.Email,
                CreatedOn = user.CreatedOn,
                IsSubscriptionExpired = user.IsSubscriptionExpired,
                SubscriptionType = user.SubscriptionType
            };

            return model;
        }
    }
}