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
    public class RouteRepository : IRouteRepository
    {
        BusTicketDbContext db;
        public RouteRepository()
        {
            db = new BusTicketDbContext();
        }

        public IEnumerable<Route> GetBusRoutes()
        {
            var BusRoutes = db.Routes.ToList();
            return BusRoutes;
        }

        public void NewRoute(Route route)
        {
            db.Routes.Add(route);
            db.SaveChanges();
            
        }
        public Route GetRoute(int id)
        {
            var route = db.Routes.Where(a => a.RouteId == id).FirstOrDefault();
            return route;
        }
        public void Edit(int id,Route route)
        {
            var busRoute = db.Routes.Find(id);
            busRoute.FromLocation = route.FromLocation;
            busRoute.ToLocation = route.ToLocation;
            
            db.SaveChanges();

        }

        public Route Delete(int id)
        {
            Route route = db.Routes.Where(a=>a.RouteId==id).FirstOrDefault();
            List<BusDetail> bus = db.BusDetails.Where(a => a.RouteId == id).ToList();
            if(bus!=null)
            {
                foreach (var i in bus)
                {
                    db.BusDetails.Remove(i);
                }
            }
           
            List<BookedSeat> bookings = db.BookedSeats.Where(a => a.BusDetail.RouteId == id).ToList();
            if(bookings!=null)
            {
                foreach (var i in bookings)
                {
                    db.BookedSeats.Remove(i);
                }
            }
           
            db.Routes.Remove(route);
            db.SaveChanges();
            return route;
        }

        
    }
}
