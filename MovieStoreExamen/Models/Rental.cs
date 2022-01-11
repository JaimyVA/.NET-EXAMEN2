using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreExamen.Models
{
    public class Rental
    {
        public int RentalId { get; set; }

        [DataType(DataType.Date)]
        public DateTime RentalDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime? RentalExpiry { get; set; }
        public Customer Customer { get; set; }
        public Movie Movie { get; set; }
    }
}
