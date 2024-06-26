using DomainModels;
using ViewModels;

namespace Mappers
{
    public static class MovieMapper
    {
        public static MovieViewModel ToModel(this Movie movie)
        {
            var model = new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Language = movie.Language,
                IsAvailable = movie.IsAvailable,
                ReleaseDate = movie.ReleaseDate,
                Length = movie.Length,
                AgeRestriction = movie.AgeRestriction,
                Quantity = movie.Quantity
            };

            return model;
        }
    }
}
