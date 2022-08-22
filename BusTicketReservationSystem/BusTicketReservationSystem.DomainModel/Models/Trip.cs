using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.DomainModel.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }

        [Display(Name = "Journey Date")]
        [Required(ErrorMessage = "Journey Date is required")]
        public DateTime JourneyDate { get; set; }


    }
}
