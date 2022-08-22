using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusTicketReservationSystem.Controllers
{
    public class LoadHtmlController : Controller
    {
        // GET: LoadHtml
        // GET: LoadHtml
        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        [ChildActionOnly]
        public ActionResult GetHtmlPage(string path)
        {
            return new FilePathResult(path, "text/html");
        }
    }
}