using BusTicketReservationSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BusTicketReservationSystem.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        ApplicationDbContext context;

        public RoleController()
        {
            this.context = new ApplicationDbContext();
        }
        [Authorize(Roles = "SuperAdmin,Admin")]
        public ActionResult Index()
        {
            try
            {
                var list = context.Users.ToList();
                return View(list);
            }
            catch(Exception)
            {
                throw new Exception("Some Error has occured while fetching the Users List. Please try again later");
            }
            
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Make_Admin(string id)
        {
            try
            {
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var user = context.Users.Where(a => a.Id == id).FirstOrDefault();
                user.UserRole = "Admin";
                UserManager.AddToRole(user.Id, "Admin");
                context.SaveChanges();


                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                throw new Exception("Some Error has occured due to which the selected user cannot become Admin. Please try again later.");
            }
        }

        public ActionResult Make_Customer(string id)
        {
            try
            {
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var user = context.Users.Where(a => a.Id == id).FirstOrDefault();
                user.UserRole = "User";
                UserManager.AddToRole(user.Id, "User");
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                throw new Exception("Some Error has occured due to which the selected Admin cannot become User. Please try again later.");
            }
            
        }
        public ActionResult CreateNewAdmin()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateNewAdmin(RegisterViewModel model)
        {
            try
            {
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, UserRole = "Admin" };
                await UserManager.CreateAsync(user, model.Password);
                UserManager.AddToRole(user.Id, "Admin");
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                throw new Exception("Some Error has occured while creating new Admin for the BTRS Portal");
            }
            
        }

        public ActionResult DeleteRecord(string id)
        {
            try
            {
                var user = context.Users.Where(a => a.Id == id).FirstOrDefault();
                context.Users.Remove(user);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                throw new Exception("Some Error has occured while deleting this record.");
            }
            
        }
    }
}