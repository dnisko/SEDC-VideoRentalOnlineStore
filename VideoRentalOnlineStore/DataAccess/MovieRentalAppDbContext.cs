using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class MovieRentalAppDbContext : DbContext
    {
        public MovieRentalAppDbContext(DbContextOptions<MovieRentalAppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }

    }
}
