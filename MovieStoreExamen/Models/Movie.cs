using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreExamen.Models
{

    [Authorize(Roles = "Administrator,Worker")]
    public class Movie
    {
        public int MovieId { get; set; }

        [Required]
        [Display(Name = "Titel")]
        public string MovieTitle { get; set; }

        [Required]
        [Display(Name = "Minimum Leeftijd")]
        public int Rating { get; set; }

        [Required]
        [Display(Name = "Leentijd")]
        public int Rental_Duration { get; set; }

        [Required]
        [Display(Name = "Aantal Gent")]
        public int Amount_Gent { get; set; }

        [Required]
        [Display(Name = "Aantal Brussel")]
        public int Amount_Brussel { get; set; }

        [Required]
        [Display(Name = "Aantal Antwerpen")]
        public int Amount_Antwerpen { get; set; }

        [Display(Name = "Teruggebracht")]
        public int Amount_Returned { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
    //public class MoviesIndexViewModel
    //{
    //    public int SelectedMovie { get; set; }
    //    public string TitleFilter { get; set; }
    //    public List<Movie> FilteredMovies { get; set; }
    //    public SelectList MoviesToSelect { get; set; }
    //}
}
