namespace DomainModels
{
    public class Rental : BaseClass
    {
        List<User> Users { get; set; }
        List<Movie> Movies { get; set; }
    }
}
