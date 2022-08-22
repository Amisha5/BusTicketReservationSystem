using BusTicketReservationSystem.DataAccessLayer;
using BusTicketReservationSystem.DomainModel.Models;
using BusTicketReservationSystem.RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.RepositoryLayer
{
   public class PaymentInitiateRepository: IPaymentInitiateRepository
    {

   
     BusTicketDbContext busTicketDbContext;
        public PaymentInitiateRepository()
        {
            busTicketDbContext = new BusTicketDbContext();
        }

        public void Success(int id)
        {
            var booked = busTicketDbContext.BookedSeats.Where(a => a.SeatId == id).FirstOrDefault();
            if (booked.A1 > 0)
            {
                booked.A1 = 1;
            }
            if (booked.A2 > 0)
            {
                booked.A2 = 1;
            }
            if (booked.A3 > 0)
            {
                booked.A3 = 1;
            }
            if (booked.A4 > 0)
            {
                booked.A4 = 1;
            }
            if (booked.A5 > 0)
            {
                booked.A5 = 1;
            }
            if (booked.A6 > 0)
            {
                booked.A6 = 1;
            }
            if (booked.A7 > 0)
            {
                booked.A7 = 1;
            }
            if (booked.A8 > 0)
            {
                booked.A8 = 1;
            }
            if (booked.A9 > 0)
            {
                booked.A9 = 1;
            }
            if (booked.A10 > 0)
            {
                booked.A10 = 1;
            }
            if (booked.B1 > 0)
            {
                booked.B1 = 1;
            }
            if (booked.B2 > 0)
            {
                booked.B2 = 1;
            }
            if (booked.B3 > 0)
            {
                booked.B3 = 1;
            }
            if (booked.B4 > 0)
            {
                booked.B4 = 1;
            }
            if (booked.B5 > 0)
            {
                booked.B5 = 1;
            }
            if (booked.B6 > 0)
            {
                booked.B6 = 1;
            }
            if (booked.B7 > 0)
            {
                booked.B7 = 1;
            }
            if (booked.B8 > 0)
            {
                booked.B8 = 1;
            }
            if (booked.B9 > 0)
            {
                booked.B9 = 1;
            }
            if (booked.B10 > 0)
            {
                booked.B10 = 1;
            }
            if (booked.C1 > 0)
            {
                booked.C1 = 1;
            }
            if (booked.C2 > 0)
            {
                booked.C2 = 1;
            }
            if (booked.C3 > 0)
            {
                booked.C3 = 1;
            }
            if (booked.C4 > 0)
            {
                booked.C4 = 1;
            }
            if (booked.C5 > 0)
            {
                booked.C5 = 1;
            }
            if (booked.C6 > 0)
            {
                booked.C6 = 1;
            }
            if (booked.C7 > 0)
            {
                booked.C7 = 1;
            }
            if (booked.C8 > 0)
            {
                booked.C8 = 1;
            }
            if (booked.C9 > 0)
            {
                booked.C9 = 1;
            }
            if (booked.C10 > 0)
            {
                booked.C10 = 1;
            }

            busTicketDbContext.SaveChanges();
        }

        public Decimal Amount(int id)
        {
            decimal sum = 0;
            var booked = busTicketDbContext.BookedSeats.Where(a => a.SeatId == id).FirstOrDefault();

            if (booked.A1 < 1 || booked.A1 > 1)
            {
                sum += booked.A1;
            }
            if (booked.A2 < 1 || booked.A2 > 1)
            {
                sum += booked.A2;
            }
            if (booked.A3 < 1 || booked.A3 > 1)
            {
                sum += booked.A3;
            }
            if (!(booked.A4 == 1))
            {
                sum += booked.A4;
            }
            if (!(booked.A5 == 1))
            {
                sum += booked.A5;
            }
            if (!(booked.A6 == 1))
            {
                sum += booked.A6;
            }
            if (!(booked.A7 == 1))
            {
                sum += booked.A7;
            }
            if (!(booked.A8 == 1))
            {
                sum += booked.A8;
            }
            if (!(booked.A9 == 1))
            {
                sum += booked.A9;
            }
            if (!(booked.A10 == 1))
            {
                sum += booked.A10;
            }
            if (booked.B1 < 1 || booked.B1 > 1)
            {
                sum += booked.B1;
            }
            if (booked.B2 < 1 || booked.B2 > 1)
            {
                sum += booked.B2;
            }
            if (booked.B3 < 1 || booked.B3 > 1)
            {
                sum += booked.B3;
            }
            if (!(booked.B4 == 1))
            {
                sum += booked.B4;
            }
            if (!(booked.B5 == 1))
            {
                sum += booked.B5;
            }
            if (!(booked.B6 == 1))
            {
                sum += booked.B6;
            }
            if (!(booked.B7 == 1))
            {
                sum += booked.B7;
            }
            if (!(booked.B8 == 1))
            {
                sum += booked.B8;
            }
            if (!(booked.B9 == 1))
            {
                sum += booked.B9;
            }
            if (!(booked.B10 == 1))
            {
                sum += booked.B10;
            }
            if (booked.C1 < 1 || booked.C1 > 1)
            {
                sum += booked.C1;
            }
            if (booked.C2 < 1 || booked.C2 > 1)
            {
                sum += booked.C2;
            }
            if (booked.C3 < 1 || booked.C3 > 1)
            {
                sum += booked.C3;
            }
            if (!(booked.C4 == 1))
            {
                sum += booked.C4;
            }
            if (!(booked.C5 == 1))
            {
                sum += booked.C5;
            }
            if (!(booked.C6 == 1))
            {
                sum += booked.C6;
            }
            if (!(booked.C7 == 1))
            {
                sum += booked.C7;
            }
            if (!(booked.C8 == 1))
            {
                sum += booked.C8;
            }
            if (!(booked.C9 == 1))
            {
                sum += booked.C9;
            }
            if (!(booked.C10 == 1))
            {
                sum += booked.C10;
            }

            if (booked.A1 == 1 && booked.A2 == 1 && booked.A3 == 1 && booked.A4 == 1 && booked.A5 == 1 && booked.A6 == 1 && booked.A7 == 1 && booked.A8 == 1 && booked.A9 == 1 && booked.A10 == 1 && booked.B1 == 1 && booked.B2 == 1 && booked.B3 == 1 && booked.B4 == 1 && booked.B5 == 1 && booked.B6 == 1 && booked.B7 == 1 && booked.B8 == 1 && booked.B9 == 1 && booked.B10 == 1 && booked.C1 == 1 && booked.C2 == 1 && booked.C3 == 1 && booked.C4 == 1 && booked.C5 == 1 && booked.C6 == 1 && booked.C7 == 1 && booked.C8 == 1 && booked.C9 == 1 && booked.C10 == 1)
            {
                sum = 0;
            }

            return sum;
        }

        public PaymentInitiateModel CreateBill(int id, PaymentInitiateModel _requestData)
        {
            _requestData.Amount = (int)Amount(id);
            // Generate random receipt number for order
            Random randomObj = new Random();
            string transactionId = randomObj.Next(10000000, 100000000).ToString();

            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_live_FG7h8MES5iTU9R", "djJ8yPC2YGhjlPZW3Y5La3XU");

            //Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_test_Yfsd7DMsBXMIkw", "DUNbrXo1YwowAt7a51G8gQm4");

            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", _requestData.Amount * 100);  // Amount will in paise
            options.Add("receipt", transactionId);
            options.Add("currency", "INR");
            options.Add("payment_capture", "0"); // 1 - automatic  , 0 - manual

            Razorpay.Api.Order orderResponse = client.Order.Create(options);
            string orderId = orderResponse["id"].ToString();
            // Create order model for return on view
            PaymentInitiateModel orderModel = new PaymentInitiateModel
            {
                OrderId = orderResponse.Attributes["id"],
                // razorpayKey = "rzp_test_Yfsd7DMsBXMIkw",
                RazorpayKey = "rzp_live_FG7h8MES5iTU9R",
                Amount = _requestData.Amount,
                Currency = "INR",
                Name = _requestData.Name,
                Email = _requestData.Email,
                PhoneNumber = _requestData.PhoneNumber,

                Description = "EasyGoing Payment Portal"
            };
            busTicketDbContext.PaymentInitiateModels.Add(orderModel);
            busTicketDbContext.SaveChanges();
            return orderModel;
        }

        public void Failed(int id)
        {
            var booked = busTicketDbContext.BookedSeats.Where(a => a.SeatId == id).FirstOrDefault();
            if (booked.A1 > 1)
            {
                booked.A1 = 0;
            }
            if (booked.A2 > 1)
            {
                booked.A2 = 0;
            }
            if (booked.A3 > 1)
            {
                booked.A3 = 0;
            }
            if (booked.A4 > 1)
            {
                booked.A4 = 0;
            }
            if (booked.A5 > 1)
            {
                booked.A5 = 0;
            }
            if (booked.A6 > 1)
            {
                booked.A6 = 0;
            }
            if (booked.A7 > 1)
            {
                booked.A7 = 0;
            }
            if (booked.A8 > 1)
            {
                booked.A8 = 0;
            }
            if (booked.A9 > 1)
            {
                booked.A9 = 0;
            }
            if (booked.A10 > 1)
            {
                booked.A10 = 0;
            }
            if (booked.B1 > 1)
            {
                booked.B1 = 0;
            }
            if (booked.B2 > 1)
            {
                booked.B2 = 0;
            }
            if (booked.B3 > 1)
            {
                booked.B3 = 0;
            }
            if (booked.B4 > 1)
            {
                booked.B4 = 0;
            }
            if (booked.B5 > 1)
            {
                booked.B5 = 0;
            }
            if (booked.B6 > 1)
            {
                booked.B6 = 0;
            }
            if (booked.B7 > 1)
            {
                booked.B7 = 0;
            }
            if (booked.B8 > 1)
            {
                booked.B8 = 0;
            }
            if (booked.B9 > 1)
            {
                booked.B9 = 0;
            }
            if (booked.B10 > 1)
            {
                booked.B10 = 0;
            }
            if (booked.C1 > 1)
            {
                booked.C1 = 0;
            }
            if (booked.C2 > 1)
            {
                booked.C2 = 0;
            }
            if (booked.C3 > 1)
            {
                booked.C3 = 0;
            }
            if (booked.C4 > 1)
            {
                booked.C4 = 0;
            }
            if (booked.C5 > 1)
            {
                booked.C5 = 0;
            }
            if (booked.C6 > 1)
            {
                booked.C6 = 0;
            }
            if (booked.C7 > 1)
            {
                booked.C7 = 0;
            }
            if (booked.C8 > 1)
            {
                booked.C8 = 0;
            }
            if (booked.C9 > 1)
            {
                booked.C9 = 0;
            }
            if (booked.C10 > 1)
            {
                booked.C10 = 0;
            }

            busTicketDbContext.SaveChanges();
        }
    }
}

