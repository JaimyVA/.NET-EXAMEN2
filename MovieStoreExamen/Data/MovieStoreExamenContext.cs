#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieStoreExamen.Models;

namespace MovieStoreExamen.Data
{
    public class MovieStoreExamenContext : DbContext
    {
        public MovieStoreExamenContext (DbContextOptions<MovieStoreExamenContext> options)
            : base(options)
        {
        }

        public DbSet<MovieStoreExamen.Models.Customer> Customer { get; set; }

        public DbSet<MovieStoreExamen.Models.Movie> Movie { get; set; }

        public DbSet<MovieStoreExamen.Models.Rental> Rental { get; set; }

        public DbSet<MovieStoreExamen.Models.Genre> Genre { get; set; }
    }
}
