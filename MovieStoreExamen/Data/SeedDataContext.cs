using Microsoft.EntityFrameworkCore;
using MovieStoreExamen.Models;

namespace MovieStoreExamen.Data
{
    public class SeedDataContext
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreExamenContext(serviceProvider.GetRequiredService
                                                                                    <DbContextOptions<MovieStoreExamenContext>>()))
            {
                context.Database.EnsureCreated();

                if (!context.Customer.Any())
                {
                    context.Customer.AddRange
                        (
                                new Customer { Name = "Jaimy", Lastname = "Van Audenhove", Birthday = DateTime.Now, Deleted = DateTime.MaxValue, strikes = 0 }
                        );
                    context.SaveChanges();
                }

                if (!context.Genre.Any() || !(context.Movie.Any()))
                {
                    context.Genre.AddRange(
                        new Genre { Name = "Actie" }, //id 1
                        new Genre { Name = "Sci-Fi" } // id 2
                        );
                    context.SaveChanges();

                    context.Movie.AddRange(
                        new Movie
                        {
                            MovieTitle = "Back to the Future",
                            Rating = 13,
                            Rental_Duration = 7,
                            Amount_Gent = 2,
                            Amount_Antwerpen = 1,
                            Amount_Brussel = 1,
                            Amount_Returned = 0,
                            GenreId = 2
                        }
                        );
                    context.SaveChanges();
                }
            }
        }
    }
}
