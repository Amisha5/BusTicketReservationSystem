using BusTicketReservationSystem.DataAccessLayer;
using BusTicketReservationSystem.DomainModel.Models;
using BusTicketReservationSystem.RepositoryContract;
using BusTicketReservationSystem.RepositoryLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BusTicketReservationSystem.Controllers
{
    public class BusDetailController : Controller
    {
        IBusDetailsRepository busrepository;

        public BusDetailController()
        {
            busrepository = new BusDetailRepository();

        }

        // GET: BusDetail
        public async Task<ActionResult> GetBusesById(int id)
        {
            string url = Globals.apiUrl + "BusDetails/";
            var BusRouteInfo = new List<BusDetail>();
            ViewBag.RouteId = id;
            TempData["id"] = id;
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync(url + id);

                if (Res.IsSuccessStatusCode)
                {

                    var BusRouteResponse = Res.Content.ReadAsStringAsync().Result;

                    BusRouteInfo = JsonConvert.DeserializeObject<List<BusDetail>>(BusRouteResponse);
                }

                return View(BusRouteInfo);
            }


        }
        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult Create(int id)
        {
            ViewBag.RouteId = id;
            TempData["Id"] = id;
            return View(new BusDetail());
        }
        [HttpPost]
        public ActionResult Create(BusDetail busDetail)
        {
            string url = Globals.apiUrl + "BusDetails";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage res = client.PostAsJsonAsync(url, busDetail).Result;
            return RedirectToAction("GetBusesById", new { id = busDetail.RouteId });

        }
        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult Edit(int id)
        {
            string url = Globals.apiUrl;
            BusDetail busDetail = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                //HTTP GET
                var responseTask = client.GetAsync("GetBus?id=" + id.ToString());


                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<BusDetail>();


                    busDetail = readTask.Result;
                }
            }

            return View(busDetail);

        }

        [HttpPost]
        public ActionResult Edit(BusDetail busDetail)
        {
            string url = Globals.apiUrl + "GetBus/";
            HttpClient client = new HttpClient();
            try
            {
                if (ModelState.IsValid)
                {
                    HttpResponseMessage response = client.PutAsJsonAsync(url + busDetail.BusId, busDetail).Result;

                    if (response.IsSuccessStatusCode)
                    {
                    }

                }
                return RedirectToAction("GetBusesById", "BusDetail", new { id = TempData["id"] });
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult Delete(int Id)
        {

            string url = Globals.apiUrl + "BusDetails/";
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.DeleteAsync(url + Id).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetBusesById", new { id = TempData["id"] });
                }

                return Content("Mistake!");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }


        [Authorize]
        public ActionResult BookSeat(int id)
        {
            try
            {
                ViewBag.BusId = id;
                ViewBag.UserName = User.Identity.Name;
                string userName = User.Identity.Name;

                BookedSeat seats_record = busrepository.BookSeat(id, userName);
                ViewBag.BusName = seats_record.BusDetail.BusName;
                ViewBag.Price = seats_record.BusDetail.Price;

                var busRoute = busrepository.RouteById(seats_record.BusDetail.RouteId);
                ViewBag.FromLocation = busRoute.FromLocation;
                ViewBag.ToLocation = seats_record.BusDetail.Route.ToLocation;

                var busTrip = busrepository.TripById(seats_record.BusDetail.TripId);
                ViewBag.JourneyDate = busTrip.JourneyDate;

                return View(seats_record);
            }
            catch(Exception)
            {
                return Content("Some Problem has occured! Book Again pls :)");
            }
        }

        public ActionResult Book(int Id, BookedSeat booking)
        {
            try
            {
                string UserName = User.Identity.Name;
                var booked_seat = busrepository.Book(Id, UserName, booking);
                return RedirectToAction("Index", "PaymentInitiate", new { id = booked_seat.SeatId });
            }
            catch(Exception)
            {
                return Content("Some Problem has occured! Sorry for the inconvenience. Please Try again later");
            }

        }
    }
}