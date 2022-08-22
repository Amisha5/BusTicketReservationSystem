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
    public class RoutesController : ApiController
    {
        
        IRouteRepository bus;
        public RoutesController()
        {
            bus = new RouteRepository();
        }
        // GET: api/Routes
        [HttpGet]
        public IEnumerable<Route> GetBusDetails()
        {
           
              return bus.GetBusRoutes();
            
            
        }

        // GET: api/Routes/5
        [ResponseType(typeof(Route))]
        public IHttpActionResult GetRoute(int id)
        {

                Route route = bus.GetRoute(id);
                if (route == null)
                {
                    return NotFound();
                }

                return Ok(route);
           
            
        }

        // PUT: api/Routes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoute(int id, Route route)
        {
            
                bus.Edit(id, route);
                return StatusCode(HttpStatusCode.NoContent);
            

        }

        // POST: api/Routes
        [ResponseType(typeof(Route))]
        public IHttpActionResult PostRoute(Route route)
        {
            
                bus.NewRoute(route);
                return CreatedAtRoute("DefaultApi", new { id = route.RouteId }, route);
            

        }

        // DELETE: api/Routes/5
        [ResponseType(typeof(Route))]
        public IHttpActionResult DeleteRoute(int id)
        {
            
                var deleteRoute = bus.Delete(id);
                return Ok(deleteRoute);
           
        }

        
    }
}