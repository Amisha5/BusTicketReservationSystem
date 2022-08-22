using BusTicketReservationSystem.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.RepositoryContract
{
   public interface IPaymentInitiateRepository
    {
        void Success(int id);
        Decimal Amount(int id);
        PaymentInitiateModel CreateBill(int id, PaymentInitiateModel _requestData);
        void Failed(int id);
    }
}
