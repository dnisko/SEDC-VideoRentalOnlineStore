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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan Length { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid number.")]
        public int AgeRestriction { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid number.")]
        public int Quantity { get; set; }
    }
}
