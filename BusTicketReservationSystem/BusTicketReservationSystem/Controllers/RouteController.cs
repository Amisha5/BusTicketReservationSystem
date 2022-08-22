using BusTicketReservationSystem.DomainModel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BusTicketReservationSystem.Controllers
{
    public class RouteController : Controller
    {
        // GET: Route
        public async Task<ActionResult> BusRoutes()
        {
            string url = Globals.apiUrl + "Routes";
           
            try
            {
                var BusRouteInfo = new List<Route>();
                using (var client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Clear();

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.GetAsync(url);

                    if (Res.IsSuccessStatusCode)
                    {

                        var BusRouteResponse = Res.Content.ReadAsStringAsync().Result;

                        BusRouteInfo = JsonConvert.DeserializeObject<List<Route>>(BusRouteResponse);
                    }

                    return View(BusRouteInfo);
                }
            }
            catch(Exception)
            {
                throw new Exception("Some Error has occured while consuming Apis. Please try Again Later");
            }
            
        }
        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult Create(int id = 0)
        {
            return View(new Route());
        }
        [HttpPost]
        public ActionResult Create(Route route)
        {
            string url = Globals.apiUrl + "Routes";
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = client.PostAsJsonAsync(url, route).Result;
                return RedirectToAction("BusRoutes");
            }
            catch(Exception)
            {
                throw new Exception("Some Error has occured while creating a new Route.Please try again later");
            }
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult Edit(int id)
        {
            string url = Globals.apiUrl;
            try
            {
                Route busRoute = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    //HTTP GET
                    var responseTask = client.GetAsync("Routes?id=" + id.ToString());


                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<Route>();


                        busRoute = readTask.Result;
                    }
                }

                return View(busRoute);
            }
            catch(Exception)
            {
                throw new Exception("Some Error has occured while fetching the Previous details. Please try again Later");
            }
        }

        [HttpPost]
        public ActionResult Edit(Route route)
        {
            string url = Globals.apiUrl + "Routes/";
            HttpClient client = new HttpClient();
            try
            {
                if (ModelState.IsValid)
                {
                    HttpResponseMessage response = client.PutAsJsonAsync(url + route.RouteId, route).Result;

                    if (response.IsSuccessStatusCode)
                    {
                    }

                }
                return RedirectToAction("BusRoutes", "Route");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult Delete(int Id)
        {
            string url = Globals.apiUrl + "Routes/";
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.DeleteAsync(url + Id).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("BusRoutes");
                }

                return Content("Mistake!");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }

        
    }
}
