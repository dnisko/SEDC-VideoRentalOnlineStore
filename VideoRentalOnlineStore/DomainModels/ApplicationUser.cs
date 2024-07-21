using DomainModels.Enums;
using Microsoft.AspNetCore.Identity;

namespace DomainModels
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public int Age { get; set; }
        public string? CardNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsSubscriptionExpired { get; set; }
        public SubscriptionType SubscriptionType { get; set; }

        public void SetCardNumber(string cardNumber)
        {
            CardNumber = cardNumber;
        }
    }
}
