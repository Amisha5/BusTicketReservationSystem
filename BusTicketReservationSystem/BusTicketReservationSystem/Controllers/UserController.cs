using BusTicketReservationSystem.DataAccessLayer;
using BusTicketReservationSystem.DomainModel.Models;
using BusTicketReservationSystem.Models;
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
    public class UserController : Controller
    {
        // GET: User
        public async Task<ActionResult> Index(string id)
        {
            string url = Globals.apiUrl + "Users/";
            try
            {
                var BusRouteInfo = new List<BookedSeat>();

                using (var client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Clear();

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.GetAsync(url+ id);

                    if (Res.IsSuccessStatusCode)
                    {

                        var BusRouteResponse = Res.Content.ReadAsStringAsync().Result;

                        BusRouteInfo = JsonConvert.DeserializeObject<List<BookedSeat>>(BusRouteResponse);
                    }

                    return View(BusRouteInfo);
                }
            }
            catch(Exception)
            {
                throw new Exception("Some Error Occured. Please try again Later!");
            }
           
        }

        public ActionResult Cancel(int id)
        {
            string url = Globals.apiUrl + "Users/";
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = client.DeleteAsync(url + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", new { id = User.Identity.Name });
                }

                return Content("Mistake!");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
           
        }

        public ActionResult ViewProfile()
        {
            ViewBag.UserName = User.Identity.Name;
          
            return View();
        }
    }
}