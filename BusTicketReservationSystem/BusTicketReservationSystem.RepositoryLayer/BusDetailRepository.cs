using BusTicketReservationSystem.DataAccessLayer;
using BusTicketReservationSystem.DomainModel.Models;
using BusTicketReservationSystem.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.RepositoryLayer
{
    public class BusDetailRepository : IBusDetailsRepository
    {
        BusTicketDbContext db;

        public BusDetailRepository()
        {
            db = new BusTicketDbContext();
        }
        public IEnumerable<BusDetail> GetBusById(int id)
        {

            var bus = db.BusDetails.Include("Route").Include("Trip").Where(a => a.RouteId == id).ToList();
            return bus;
        }
        public void NewBus(BusDetail busDetail)
        {

            db.BusDetails.Add(busDetail);
            db.SaveChanges();
        }

        public BusDetail Delete(int id)
        {
            BusDetail busDetail = db.BusDetails.Include("Trip").Where(a => a.BusId == id).FirstOrDefault();

            List<BookedSeat> bookings = db.BookedSeats.Where(a => a.BusDetail.BusId == id).ToList();
            if (bookings != null)
            {
                foreach (var i in bookings)
                {
                    db.BookedSeats.Remove(i);
                }

            }

            db.BusDetails.Remove(busDetail);
            db.SaveChanges();
            return busDetail;
        }

        public BusDetail GetSingleBusById(int id)
        {
            var bus = db.BusDetails.Include("Route").Include("Trip").Where(a => a.BusId == id).FirstOrDefault();
            return bus;
        }

        public BusDetail Edit(int id, BusDetail busDetails)
        {
            var busDetail = db.BusDetails.Include("Route").Include("Trip").Where(a => a.BusId == id).FirstOrDefault();
            busDetail.RouteId = busDetails.RouteId;
            busDetail.BusName = busDetails.BusName;
            busDetail.Capacity = busDetails.Capacity;
            busDetail.Category = busDetails.Category;
            busDetail.Price = busDetails.Price;
            db.SaveChanges();
            return busDetail;

        }

        public BookedSeat BookSeat(int id, string username)
        {
            BusDetail Bus = db.BusDetails.Include("Trip").Where(a => a.BusId == id).SingleOrDefault();
            DateTime current_time = new DateTime();
            current_time = DateTime.Now;

            if (current_time > Bus.Trip.JourneyDate)

            {
                var seats = db.BookedSeats.Include("BusDetail").Include("BusDetail.Route").Include("BusDetail.Trip")
                .Where(e => e.BusId == id).FirstOrDefault();
                seats.A1 = 0;
                seats.A2 = 0;
                seats.A3 = 0;
                seats.A4 = 0;
                seats.A5 = 0;
                seats.A6 = 0;
                seats.A7 = 0;
                seats.A8 = 0;
                seats.A9 = 0;
                seats.A10 = 0;
                seats.B1 = 0;
                seats.B2 = 0;
                seats.B3 = 0;
                seats.B4 = 0;
                seats.B5 = 0;
                seats.B6 = 0;
                seats.B7 = 0;
                seats.B8 = 0;
                seats.B9 = 0;
                seats.B10 = 0;
                seats.C1 = 0;
                seats.C2 = 0;
                seats.C3 = 0;
                seats.C4 = 0;
                seats.C5 = 0;
                seats.C6 = 0;
                seats.C7 = 0;
                seats.C8 = 0;
                seats.C9 = 0;
                seats.C10 = 0;
                db.SaveChanges();

            }




            var find_booking = db.BookedSeats.Include("BusDetail").Include("BusDetail.Route").Include("BusDetail.Trip")
                .Where(e => e.BusId == id).ToList();
            if (find_booking.Count == 0)
            {
                var books = new BookedSeat
                {

                    UserId = "Initial_Seats",
                    BusId = id,


                    A1 = 0,
                    A2 = 0,
                    A3 = 0,
                    A4 = 0,
                    A5 = 0,
                    A6 = 0,
                    A7 = 0,
                    A8 = 0,
                    A9 = 0,
                    A10 = 0,
                    B1 = 0,
                    B2 = 0,
                    B3 = 0,
                    B4 = 0,
                    B5 = 0,
                    B6 = 0,
                    B7 = 0,
                    B8 = 0,
                    B9 = 0,
                    B10 = 0,
                    C1 = 0,
                    C2 = 0,
                    C3 = 0,
                    C4 = 0,
                    C5 = 0,
                    C6 = 0,
                    C7 = 0,
                    C8 = 0,
                    C9 = 0,
                    C10 = 0,

                };

                db.BookedSeats.Add(books);
                db.SaveChanges();

                return books;
            }
            else
            {
                var max = find_booking.OrderByDescending(p => p.SeatId).FirstOrDefault().SeatId;
                var booked = db.BookedSeats.Include("BusDetail").Include("BusDetail.Route").Include("BusDetail.Trip")
                    .Where(e => e.SeatId == max).FirstOrDefault();
                booked.UserId = username;
                booked.BusId = id;

                return booked;
            }
        }

        public BookedSeat Book(int id, string username, BookedSeat booking)
        {
            int max = db.BookedSeats.Max(p => p.SeatId);
            var alreadybooked = db.BookedSeats.Find(max);

            alreadybooked.BusId = booking.BusId;
            alreadybooked.UserId = username;
            alreadybooked.A1 = booking.A1;
            alreadybooked.A2 = booking.A2;
            alreadybooked.A3 = booking.A3;
            alreadybooked.A4 = booking.A4;
            alreadybooked.A5 = booking.A5;
            alreadybooked.A6 = booking.A6;
            alreadybooked.A7 = booking.A7;
            alreadybooked.A8 = booking.A8;
            alreadybooked.A9 = booking.A9;
            alreadybooked.A10 = booking.A10;
            alreadybooked.B1 = booking.B1;
            alreadybooked.B2 = booking.B2;
            alreadybooked.B3 = booking.B3;
            alreadybooked.B4 = booking.B4;
            alreadybooked.B5 = booking.B5;
            alreadybooked.B6 = booking.B6;
            alreadybooked.B7 = booking.B7;
            alreadybooked.B8 = booking.B8;
            alreadybooked.B9 = booking.B9;
            alreadybooked.B10 = booking.B10;
            alreadybooked.C1 = booking.C1;
            alreadybooked.C2 = booking.C2;
            alreadybooked.C3 = booking.C3;
            alreadybooked.C4 = booking.C4;
            alreadybooked.C5 = booking.C5;
            alreadybooked.C6 = booking.C6;
            alreadybooked.C7 = booking.C7;
            alreadybooked.C8 = booking.C8;
            alreadybooked.C9 = booking.C9;
            alreadybooked.C10 = booking.C10;

            db.BookedSeats.Add(alreadybooked);
            db.SaveChanges();

            return alreadybooked;
        }

        public Route RouteById(int id)
        {
            var busRoute = db.Routes.Find(id);
            return busRoute;
        }

        public Trip TripById(int id)
        {
            var busTrip = db.Trips.Find(id);
            return busTrip;
        }
    }
}
