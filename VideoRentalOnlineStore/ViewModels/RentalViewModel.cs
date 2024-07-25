using System.ComponentModel.DataAnnotations;
using DomainModels;

namespace ViewModels
{
    public class RentalViewModel
    {
        public int Id { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime RentedOn { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? ReturnedOn { get; set; }
        public DateTime DueDate { get; set; }
        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
