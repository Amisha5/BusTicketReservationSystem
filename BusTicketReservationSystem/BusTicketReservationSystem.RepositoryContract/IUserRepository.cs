using BusTicketReservationSystem.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.RepositoryContract
{
    public interface IUserRepository
    {
        IEnumerable<BookedSeat> GetBookingHistory(string id);
        IEnumerable<FeedBack> GetFeedBack();
        void Cancel_Ticket(int id);
        void AddFeedBack(FeedBack feedBack);

    }
}
