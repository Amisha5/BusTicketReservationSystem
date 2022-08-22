using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.DomainModel.Models
{
   
    public class Route
    {
        [Key]
        [Required(ErrorMessage = "RouteID is Required")]
        public int RouteId { get; set; }
        [Display(Name ="From Location")]
        [Required(ErrorMessage = "Destination-From is Required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "FromLocation only contains Alphabates")]
        public string FromLocation { get; set; }
        [Display(Name = "To Location")]
        [Required(ErrorMessage = "Destination-To is Required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "ToLocation only contains Alphabates")]
        public string ToLocation { get; set; }
        
        

    }
}
