using DomainModels.Enums;

namespace DomainModels
{
    public class Movie : BaseClass
    {
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public Language Language { get; set; }
        //public Part Part { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Length { get; set; }
        public int AgeRestriction { get; set; }
        public int Quantity { get; set; }
    }
}
