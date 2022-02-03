using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieStoreExamen.Areas.Identity.Data;
using MovieStoreExamen.Models;

namespace MovieStoreExamen.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<MovieStoreExamen.Models.Customer> Customer { get; set; }

    public DbSet<MovieStoreExamen.Models.Movie> Movie { get; set; }

    public DbSet<MovieStoreExamen.Models.Rental> Rental { get; set; }

    public DbSet<MovieStoreExamen.Models.Genre> Genre { get; set; }

    public DbSet<MovieStoreExamen.Models.Genre> Language { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<MovieStoreExamen.Areas.Identity.Data.ApplicationUserViewModel> ApplicationUserViewModel { get; set; }
}
