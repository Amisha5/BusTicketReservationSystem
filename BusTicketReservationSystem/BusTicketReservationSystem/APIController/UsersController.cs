using BusTicketReservationSystem.DomainModel.Models;
using BusTicketReservationSystem.RepositoryContract;
using BusTicketReservationSystem.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BusTicketReservationSystem.APIController
{
    public class UsersController : ApiController
    {
        IUserRepository user;
        public UsersController()
        {
            user = new UserRepository();
        }

        public IEnumerable<BookedSeat> GetBookingHistory(string id)
        {
            try
            {
                return user.GetBookingHistory(id);
            }
            catch(Exception)
            {
                throw new Exception("Some Error has occured while fetching the details through WebApi. Please try again later");
            }
        }

        [HttpDelete]
        public IHttpActionResult Cancel_Ticket(int id)
        {
            try
            {
                user.Cancel_Ticket(id);
                return Ok();
            }
            catch(Exception)
            {
                throw new Exception("Some Error has occured while Canceling the Ticket through WebApi. Please try again later");
            }
            
        }
    }
}
