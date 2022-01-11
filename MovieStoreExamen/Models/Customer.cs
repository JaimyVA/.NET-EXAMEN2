using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MovieStoreExamen.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Voornaam")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Achternaam")]
        public string Lastname { get; set; }

        [Required]
        [Display(Name = "Geboortedatum")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public DateTime? Deleted { get; set; } = DateTime.MaxValue;
        public int strikes { get; set; }
    }

    //public class CustomerIndexViewModel
    //{
    //    public int SelectedCustomer { get; set; }
    //    public string NameFilter { get; set; }
    //    public List<Customer> FilteredCustomers { get; set;}
    //    public SelectList CustomersToSelect { get; set; }
    //}
}
