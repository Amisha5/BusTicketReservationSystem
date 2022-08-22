using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BusTicketReservationSystem.DataAccessLayer;
using BusTicketReservationSystem.DomainModel.Models;
using BusTicketReservationSystem.RepositoryContract;
using BusTicketReservationSystem.RepositoryLayer;

namespace BusTicketReservationSystem.APIController
{
    public class GetBusController : ApiController
    {
        private IBusDetailsRepository bus;
        public GetBusController()
        {
            bus = new BusDetailRepository();
        }

        [ResponseType(typeof(BusDetail))]
        public IHttpActionResult GetBusDetail(int id)
        {
           
                BusDetail busDetail = bus.GetSingleBusById(id);
                if (busDetail == null)
                {
                    return NotFound();
                }

                return Ok(busDetail);
           
           
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoute(int id, BusDetail busDetail)
        {
          
                bus.Edit(id, busDetail);
                return StatusCode(HttpStatusCode.NoContent);
 
        }


    }
}