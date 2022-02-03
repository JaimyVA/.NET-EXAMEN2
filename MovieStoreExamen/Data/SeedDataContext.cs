using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieStoreExamen.Areas.Identity.Data;
using MovieStoreExamen.Models;

namespace MovieStoreExamen.Data
{
    public class SeedDataContext
    {
        public static void Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService
                                                                                    <DbContextOptions<ApplicationDbContext>>()))
            {
                ApplicationUser Administrator = null;
                ApplicationUser Customer1 = null;
                ApplicationUser Worker1 = null;
                context.Database.EnsureCreated();

                if (!context.Users.Any())
                {
                    Administrator = new ApplicationUser
                    {
                        UserName = "Admin",
                        FirstName = "Jaimy",
                        LastName = "Van Audenhove",
                        Email = "Admin@MovieStore.be",
                        EmailConfirmed = true
                    };

                    Customer1 = new ApplicationUser
                    {
                        UserName = "Customer1",
                        FirstName = "Klant",
                        LastName = "Customer",
                        Email = "Customer1@MovieStore.be",
                        EmailConfirmed = true
                    };

                    Worker1 = new ApplicationUser
                    {
                        UserName = "Worker1",
                        FirstName = "Winkel",
                        LastName = "Medewerker",
                        Email = "Worker1@MovieStore.be",
                        EmailConfirmed = true
                    };

                    userManager.CreateAsync(Administrator, "Student+1");
                    userManager.CreateAsync(Customer1, "MovieStore123");
                    userManager.CreateAsync(Worker1, "MovieStore123");

                }

                if (!context.Roles.Any())
                {
                     context.Roles.AddRange(
                             new IdentityRole { Id = "Administrator", Name = "Administrator", NormalizedName = "administrator" },
                             new IdentityRole { Id = "Customer", Name = "Customer", NormalizedName = "customer" },
                             new IdentityRole { Id = "Worker", Name = "Worker", NormalizedName = "worker" }
                             );

                     context.SaveChanges();
                }


                if (!context.Customer.Any())
                {
                    context.Customer.AddRange
                        (
                                new Customer { Name = "Test", Lastname = "Klant", Birthday = DateTime.Now, Deleted = DateTime.MaxValue, strikes = 0 }
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

                if (Administrator != null && Customer1 != null && Worker1 != null)
                {
                    context.UserRoles.AddRange(

                        new IdentityUserRole<string> { UserId = Administrator.Id, RoleId = "Administrator" },
                        new IdentityUserRole<string> { UserId = Customer1.Id, RoleId = "Customer" },
                        new IdentityUserRole<string> { UserId = Worker1.Id, RoleId = "Worker" }

                        );

                    context.SaveChanges();
                }
            }
        }
    }
}
