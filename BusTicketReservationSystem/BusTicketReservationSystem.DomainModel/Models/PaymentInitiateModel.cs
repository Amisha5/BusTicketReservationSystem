using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.DomainModel.Models
{
    public class PaymentInitiateModel
    {
        [Key]
        public int Id { get; set; }
        public string OrderId { get; set; }
        public string RazorpayKey { get; set; }
        public string Currency { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage ="Email Id is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Phone Number is Required")]

        [RegularExpression(@"[6-9]{1}[0-9]{9}",ErrorMessage ="Mobile number should start with 6,7,8,9")]
        public string PhoneNumber { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
    }
}
