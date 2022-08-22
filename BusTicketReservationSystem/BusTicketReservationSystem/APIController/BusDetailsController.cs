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
    public class BusDetailsController : ApiController
    {
        IBusDetailsRepository ibus;
        public BusDetailsController()
        {
            ibus = new BusDetailRepository();
        }

        [ResponseType(typeof(BusDetail))]
        public IEnumerable<BusDetail> GetBusDetail(int id)
        {
            try
            {
                var busDetail = ibus.GetBusById(id);
                return busDetail;
            }
            catch(Exception)
            {
                throw new Exception("Some Error has occured while fetching the details through WebApi. Please try again later");
            }
            
        }

        // POST: api/BusDetails
        [ResponseType(typeof(BusDetail))]
        public IHttpActionResult PostBusDetail(BusDetail busDetail)
        {
            try
            {
                ibus.NewBus(busDetail);

                return CreatedAtRoute("DefaultApi", new { id = busDetail.BusId }, busDetail);
            }
            catch(Exception)
            {
                throw new Exception("Some Error has occured while Updating the details through WebApi. Please try again later");
            }

            
        }

        // DELETE: api/BusDetails/5
        [ResponseType(typeof(BusDetail))]
        public void DeleteBusDetail(int id)
        {
            try
            {
                ibus.Delete(id);
            }
            catch(Exception)
            {
                throw new Exception("Some Error has occured while Deleting the detail through WebApi. Please try again later");
            }
            
        }

        
    }
}