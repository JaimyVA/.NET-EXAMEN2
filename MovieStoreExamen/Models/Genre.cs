using System.ComponentModel.DataAnnotations;

namespace MovieStoreExamen.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public string Name { get; set; }
    }
}
