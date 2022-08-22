using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.DomainModel.Models
{
    public class BusDetail
    {
        [Key]   
        public int BusId { get; set; }
        [Required(ErrorMessage = "BusName is Required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name only contains Alphabates")]
        public string BusName { get; set; }
        public Category Category { get; set; }   //Bus Category   
        public Capacity Capacity { get; set; }   //Bus Seat Capacity
        public int RouteId { get; set; }
        [ForeignKey("RouteId")]
        public Route Route { get; set; }
        [Required(ErrorMessage = "Enter Price")]
        [Range(2, 5000)]
        public decimal Price { get; set; }
        public int TripId { get; set; }
        [ForeignKey("TripId")]
        public Trip Trip { get; set; }
    }
}
