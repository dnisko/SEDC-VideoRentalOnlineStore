using DomainModels;
using DomainModels.Enums;

namespace DataAccess
{
    public class StaticDb
    {
        public static User Users = new User()
        {
            Id = 0,
            FirstName = "Dino",
            LastName = "Nik",
            UserName = "dino",
            Password = "asd",
            Email = "d@d.d",
            CardNumber = "1234"
        };

        public static Movie Movies = new Movie()
        {
            Id = 0,
            Title = "Star Wars",
            Genre = Genre.Adventure,
            Language = Language.English,
            Part = Part.PartI,
            ReleaseDate = new DateTime(1980, 6, 18);
            Length = "02:50",
            AgeRestriction = 13,
            Quantity = 10
        };
    }
}