using BusTicketReservationSystem.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.RepositoryContract
{
    public interface IBusDetailsRepository
    {
        IEnumerable<BusDetail> GetBusById(int id);
        void NewBus(BusDetail busDetail);

        BookedSeat BookSeat(int id, string username);

        BookedSeat Book(int id, string username, BookedSeat booking);

        Route RouteById(int id);

        Trip TripById(int id);
        BusDetail GetSingleBusById(int id);
        BusDetail Edit(int id, BusDetail busDetails);

        BusDetail Delete(int id);
    }
}
