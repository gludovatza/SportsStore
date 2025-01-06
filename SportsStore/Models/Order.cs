using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        public ICollection<CartLine> Lines = new List<CartLine>();
        [Required(ErrorMessage = "Please enter name")]
        public string? Name  { get; set;}
        [Required(ErrorMessage = "Please the first adress line")]
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Line3 { get; set; }
        [Required(ErrorMessage = "Please the city name")]
        public string? City { get; set; }
        [Required(ErrorMessage = "Please the state name")]
        public string? State { get; set; }
        public string? Zip { get; set; }
        [Required(ErrorMessage = "Please the country name")]
        public string? Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
