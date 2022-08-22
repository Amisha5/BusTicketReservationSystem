using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.DomainModel.Models
{
    public class FeedBack
    {
        [Key]
        public int FeedBackId { get; set; }
        [Required(ErrorMessage = "UserId is Required")]
        public string UserId { get; set; }
        public string HowSatisfied { get; set; }
        public string IsLiked { get; set; }
        [Required(ErrorMessage = "Rating is Required")]
        public double Rating { get; set; }
        public int BusId { get; set; }
        [ForeignKey("BusId")]
        public BusDetail BusDetails { get; set; }
        public string Comment { get; set; }
    }

}
