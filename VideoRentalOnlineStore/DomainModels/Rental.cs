namespace DomainModels
{
    public class Rental : BaseClass
    {
        //List<User> Users { get; set; }
        //List<Movie> Movies { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public DateTime RentedOn { get; set; }
        public DateTime ReturnedOn { get; set; }
    }
}
