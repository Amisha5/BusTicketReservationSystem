using BusTicketReservationSystem.DataAccessLayer;
using BusTicketReservationSystem.DomainModel.Models;
using BusTicketReservationSystem.RepositoryContract;
using BusTicketReservationSystem.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusTicketReservationSystem.Controllers
{
    public class HomeController : Controller
    {
        IUserRepository iUserRepository;
        public HomeController()
        {
            iUserRepository = new UserRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult FeedBack()
        {
            BusTicketDbContext bus = new BusTicketDbContext();
            ViewBag.BusDetail = bus.BusDetails.ToList();
            ViewBag.UserID = User.Identity.Name;
            return View();
        }
        [HttpPost]
        public ActionResult FeedBack(FeedBack feedBack)
        {
            iUserRepository.AddFeedBack(feedBack);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult GetAllFeedBack()
        {
            var list = iUserRepository.GetFeedBack();
            return View(list);
        }
    }
}