using DomainModels;
using DomainModels.Enums;

namespace DataAccess
{
    public class Storage
    {
        public StorageSet<User> Users { get; set; } = new();
        public StorageSet<Movie> Movies { get; set; } = new();
        public StorageSet<Rental> Rentals { get; set; } = new();

        public Storage()
        {
            if (!Users.GetAll().Any())
            {
                //JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                var user = new User();
                user.Id = 0;
                user.FirstName = "Dino";
                user.LastName = "Nikolovski";
                user.UserName = "dino";
                user.Password = "asd";
                user.CardNumber = "1234";
                user.Email = "dino@a.a";

                Users.Add(user);
                
                //string json = JsonConvert.SerializeObject(Users.GetAll());
               
                // Deserialize JSON back to a collection of User objects
                //var deserializedUsers = JsonConvert.DeserializeObject<List<User>>(json);
            }

            if (!Movies.GetAll().Any())
            {
                //Trainers.Add(new Trainer(0, "Test", "TestLN", "test", "12345test", new List<User>(Users.GetAll())));
                var movie = new Movie();
                movie.Id = 0;
                movie.Title = "Star Wars";
                movie.Genre = Genre.Adventure;
                movie.Language = Language.English;
                movie.Part = Part.PartI;
                movie.ReleaseDate = new DateTime(1980, 6, 18);
                movie.Length = "02:50";
                movie.AgeRestriction = 10;
                movie.Quantity = 10;

                Movies.Add(movie);
            }
        }
    }
}
