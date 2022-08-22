using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.DomainModel.Models
{
	public class BookedSeat
	{
		[Key]
		
		public int SeatId { get; set; }
		[Required(ErrorMessage = "User ID is Required")]
		public string UserId { get; set; }
		public int BusId { get; set; }
		[ForeignKey("BusId")]
		public BusDetail BusDetail { get; set; }

	
		//Bus Seats
		public decimal A1 { get; set; }
		public decimal A2 { get; set; }
		public decimal A3 { get; set; }
		public decimal A4 { get; set; }
		public decimal A5 { get; set; }
		public decimal A6 { get; set; }
		public decimal A7 { get; set; }
		public decimal A8 { get; set; }
		public decimal A9 { get; set; }
		public decimal A10 { get; set; }

		public decimal B1 { get; set; }
		public decimal B2 { get; set; }
		public decimal B3 { get; set; }
		public decimal B4 { get; set; }
		public decimal B5 { get; set; }
		public decimal B6 { get; set; }
		public decimal B7 { get; set; }
		public decimal B8 { get; set; }
		public decimal B9 { get; set; }
		public decimal B10 { get; set; }

		public decimal C1 { get; set; }
		public decimal C2 { get; set; }
		public decimal C3 { get; set; }
		public decimal C4 { get; set; }
		public decimal C5 { get; set; }
		public decimal C6 { get; set; }
		public decimal C7 { get; set; }
		public decimal C8 { get; set; }
		public decimal C9 { get; set; }
		public decimal C10 { get; set; }

		
	}
}
