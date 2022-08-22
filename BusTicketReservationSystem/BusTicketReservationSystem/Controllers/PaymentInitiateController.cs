using BusTicketReservationSystem.DataAccessLayer;
using BusTicketReservationSystem.DomainModel.Models;
using BusTicketReservationSystem.RepositoryContract;
using BusTicketReservationSystem.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BusTicketReservationSystem.Controllers
{
    public class PaymentInitiateController : Controller
    {
        IPaymentInitiateRepository paymentInitiateRepository;
        public PaymentInitiateController()
        {
            paymentInitiateRepository = new PaymentInitiateRepository();
        }
        public ActionResult Amount_Zero()
        {
            return View();
        }
        public ActionResult Index(int id)
        {
            TempData["Id"] = id;
            var amount = paymentInitiateRepository.Amount(id);
            ViewBag.Total = (int)amount;
            if (amount == 0)
            {
                return RedirectToAction("Amount_Zero");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(PaymentInitiateModel _requestData)
        {
            try
            {
                int id = (int)TempData["Id"];
                TempData["Id1"] = id;
                var orderModel = paymentInitiateRepository.CreateBill(id, _requestData);
                return View("PaymentPage", orderModel);
            }
            catch(Exception)
            {
                return Content("Some problem has occured!");
            }
            

        }

        [HttpPost]
        public ActionResult Complete()
        {


            string paymentId = Request.Params["rzp_paymentid"];

            string orderId = Request.Params["rzp_orderid"];
            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient(Globals.RazorPayKey, Globals.RazorPaySecret);

            Razorpay.Api.Payment payment = client.Payment.Fetch(paymentId);

            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", payment.Attributes["amount"]);
            Razorpay.Api.Payment paymentCaptured = payment.Capture(options);
            string amt = paymentCaptured.Attributes["amount"];

            if (paymentCaptured.Attributes["status"] == "captured")
            {

                return RedirectToAction("Success");
            }
            else
            {
                return RedirectToAction("Failed");
            }


        }
        public ActionResult Success()
        {
            try
            {
                int id = (int)TempData["Id1"];
                paymentInitiateRepository.Success(id);
                return View();
            }
            catch(Exception)
            {
                return View();
            }


        }
        public ActionResult Failed()
        {
            if(TempData["Id1"]==null)
            {
                return View();
            }
            try
            {
                int id = (int)TempData["Id1"];
                paymentInitiateRepository.Failed(id);
                return View();
            }
            catch(Exception)
            {
                return View();
            }
        }
    }
}