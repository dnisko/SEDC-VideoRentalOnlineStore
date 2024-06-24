using DomainModels.Enums;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FullName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "The CardNumber field must contain exactly 10 digits.")]
        public string CardNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsSubscriptionExpired { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
    }
}