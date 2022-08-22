using BusTicketReservationSystem.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.RepositoryContract
{
    public interface IRouteRepository
    {
        IEnumerable<Route> GetBusRoutes();

        void NewRoute(Route route);

        void Edit(int id, Route route);

        Route GetRoute(int id);
        Route Delete(int id);
        

    }
}
