using BusTicketReservationSystem.DataAccessLayer;
using BusTicketReservationSystem.DomainModel.Models;
using BusTicketReservationSystem.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.RepositoryLayer
{
    public class UserRepository:IUserRepository
    {
        BusTicketDbContext busTicketDbContext = new BusTicketDbContext();
    
        public IEnumerable<BookedSeat> GetBookingHistory(string id)
        {
            var result = busTicketDbContext.BookedSeats.Include("BusDetail").Include("BusDetail.Route").Include("BusDetail.Trip").Where(a => a.UserId == id).ToList();
            return result;
        }

        public void Cancel_Ticket(int id)
        {
            var ticket_to_cancel = busTicketDbContext.BookedSeats.Include("BusDetail").Include("BusDetail.Trip").Include("BusDetail.Route").Where(a => a.SeatId == id).FirstOrDefault();
            int CancelTicket_Bus_id = ticket_to_cancel.BusId;
            var bus= busTicketDbContext.BookedSeats.Include("BusDetail").Include("BusDetail.Route").Include("BusDetail.Trip").Where(i => i.SeatId < ticket_to_cancel.SeatId && i.BusId== ticket_to_cancel.BusId).ToList();
            var previous_recordId = bus.OrderByDescending(p => p.SeatId).FirstOrDefault().SeatId;
            var previous_record= busTicketDbContext.BookedSeats.Include("BusDetail").Include("BusDetail.Trip").Include("BusDetail.Route").Where(a => a.SeatId == previous_recordId).FirstOrDefault();
            var Bus_list = busTicketDbContext.BookedSeats.Include("BusDetail").Include("BusDetail.Route").Include("BusDetail.Trip").Where(i => i.BusId == CancelTicket_Bus_id).ToList();
            var latest_recordId = Bus_list.OrderByDescending(p => p.SeatId).FirstOrDefault().SeatId;
            var latest_record= busTicketDbContext.BookedSeats.Include("BusDetail").Include("BusDetail.Route").Include("BusDetail.Trip").Where(i => i.SeatId == latest_recordId).FirstOrDefault();
            if(previous_record!=null && latest_record!=null)
            {
                if((previous_record.A1+latest_record.A1+ ticket_to_cancel.A1)==2)
                {
                    latest_record.A1 = 0;
                }
                if ((previous_record.A2 + latest_record.A2 + ticket_to_cancel.A2) == 2)
                {
                    latest_record.A2 = 0;
                }
                if ((previous_record.A3 + latest_record.A3 + ticket_to_cancel.A3) == 2)
                {
                    latest_record.A3 = 0;
                }
                if ((previous_record.A4 + latest_record.A4 + ticket_to_cancel.A4) == 2)
                {
                    latest_record.A4 = 0;
                }
                if ((previous_record.A5 + latest_record.A5 + ticket_to_cancel.A5) == 2)
                {
                    latest_record.A5 = 0;
                }
                if ((previous_record.A6 + latest_record.A6 + ticket_to_cancel.A6) == 2)
                {
                    latest_record.A6 = 0;
                }
                if ((previous_record.A7 + latest_record.A7 + ticket_to_cancel.A7) == 2)
                {
                    latest_record.A7 = 0;
                }
                if ((previous_record.A8 + latest_record.A8 + ticket_to_cancel.A8) == 2)
                {
                    latest_record.A8 = 0;
                }
                if ((previous_record.A9 + latest_record.A9 + ticket_to_cancel.A9) == 2)
                {
                    latest_record.A9 = 0;
                }
                if ((previous_record.A10 + latest_record.A10 + ticket_to_cancel.A10) == 2)
                {
                    latest_record.A10 = 0;
                }
                if ((previous_record.B1 + latest_record.B1 + ticket_to_cancel.B1) == 2)
                {
                    latest_record.B1 = 0;
                }
                if ((previous_record.B2 + latest_record.B2 + ticket_to_cancel.B2) == 2)
                {
                    latest_record.B2 = 0;
                }
                if ((previous_record.B3 + latest_record.B3 + ticket_to_cancel.B3) == 2)
                {
                    latest_record.B3 = 0;
                }
                if ((previous_record.B4 + latest_record.B4 + ticket_to_cancel.B4) == 2)
                {
                    latest_record.B4 = 0;
                }
                if ((previous_record.B5 + latest_record.B5 + ticket_to_cancel.B5) == 2)
                {
                    latest_record.B5 = 0;
                }
                if ((previous_record.B6 + latest_record.B6 + ticket_to_cancel.B6) == 2)
                {
                    latest_record.B6 = 0;
                }
                if ((previous_record.B7 + latest_record.B7 + ticket_to_cancel.B7) == 2)
                {
                    latest_record.B7 = 0;
                }
                if ((previous_record.B8 + latest_record.B8 + ticket_to_cancel.B8) == 2)
                {
                    latest_record.B8 = 0;
                }
                if ((previous_record.B9 + latest_record.B9 + ticket_to_cancel.B9) == 2)
                {
                    latest_record.B9 = 0;
                }
                if ((previous_record.B10 + latest_record.B10 + ticket_to_cancel.B10) == 2)
                {
                    latest_record.B10 = 0;
                }
                if ((previous_record.C1 + latest_record.C1 + ticket_to_cancel.C1) == 2)
                {
                    latest_record.C1 = 0;
                }
                if ((previous_record.C2 + latest_record.C2 + ticket_to_cancel.C2) == 2)
                {
                    latest_record.C2 = 0;
                }
                if ((previous_record.C3 + latest_record.C3 + ticket_to_cancel.C3) == 2)
                {
                    latest_record.C3 = 0;
                }
                if ((previous_record.C4 + latest_record.C4 + ticket_to_cancel.C4) == 2)
                {
                    latest_record.C4 = 0;
                }
                if ((previous_record.C5 + latest_record.C5 + ticket_to_cancel.C5) == 2)
                {
                    latest_record.C5 = 0;
                }
                if ((previous_record.C6 + latest_record.C6 + ticket_to_cancel.C6) == 2)
                {
                    latest_record.C6 = 0;
                }
                if ((previous_record.C7 + latest_record.C7 + ticket_to_cancel.C7) == 2)
                {
                    latest_record.C7 = 0;
                }
                if ((previous_record.C8 + latest_record.C8 + ticket_to_cancel.C8) == 2)
                {
                    latest_record.C8 = 0;
                }
                if ((previous_record.C9 + latest_record.C9 + ticket_to_cancel.C9) == 2)
                {
                    latest_record.C9 = 0;
                }
                if ((previous_record.C10 + latest_record.C10 + ticket_to_cancel.C10) == 2)
                {
                    latest_record.C10 = 0;
                }


            }
            busTicketDbContext.BookedSeats.Remove(ticket_to_cancel);
            busTicketDbContext.SaveChanges();
        }

        public void AddFeedBack(FeedBack feedBack)
        {
            busTicketDbContext.FeedBacks.Add(feedBack);
            busTicketDbContext.SaveChanges();
        }

        public IEnumerable<FeedBack> GetFeedBack()
        {
            var listFeedBack = busTicketDbContext.FeedBacks.Include(b => b.BusDetails).ToList();
            return listFeedBack;
        }
    }
}
