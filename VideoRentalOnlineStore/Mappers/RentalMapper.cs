using DomainModels;
using ViewModels;

namespace Mappers
{
    public static class RentalMapper
    {
        public static RentalViewModel ToModel(this Rental rental)
        {
            var model = new RentalViewModel
            {
                Id = rental.Id,
                MovieId = rental.MovieId,
                UserId = rental.UserId,
                RentedOn = rental.RentedOn//,
                //ReturnedOn = rental.ReturnedOn
            };

            return model;
        }
    }
}
