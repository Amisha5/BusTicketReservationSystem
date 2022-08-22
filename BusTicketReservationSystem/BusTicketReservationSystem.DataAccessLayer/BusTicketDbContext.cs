using BusTicketReservationSystem.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.DataAccessLayer
{
    public class BusTicketDbContext:DbContext
    {
        public BusTicketDbContext():base("Conn")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<PaymentInitiateModel> PaymentInitiateModels { get; set; }
        public DbSet<BookedSeat> BookedSeats { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<BusDetail> BusDetails { get; set; }
        public DbSet<Route> Routes { get; set; }
       
        public DbSet<Trip> Trips { get; set; }
    }
}
