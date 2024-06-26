using System.ComponentModel.DataAnnotations;
using DomainModels.Enums;

namespace ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public Language Language { get; set; }
        public bool IsAvailable { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public TimeSpan Length { get; set; }
        [Required]
        [MinLength(2)]
        public int AgeRestriction { get; set; }
        [Required]
        [MinLength(2)]
        public int Quantity { get; set; }
    }
}
