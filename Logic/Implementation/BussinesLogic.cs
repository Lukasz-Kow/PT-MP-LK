using Data.API;
using Logic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Implementation
{
    internal class BussinesLogic : IBussinesLogic
    {
        private IDataRepository DataRepo;

        public BussinesLogic(IDataRepository dataRepo)
        {
            DataRepo = dataRepo;
        }

        public override void BuyBook(string customerId, string statusId)
        {
            if (!DataRepo.IsAvailable(statusId)) throw new InvalidOperationException("Can't rent this book, it is not available. ");
            IBuy buy = new Buy(statusId, customerId);
            DataRepo.AddEvent(buy);
            DataRepo.ChangeAvailability(statusId);
        }

        public override void ReturnBook(string customerId, string statusId)
        {
            if (DataRepo.IsAvailable(statusId)) throw new InvalidOperationException("Can't return this book, it's available now");
            DataRepo.AddEvent(new Return(statusId, customerId));
            DataRepo.ChangeAvailability(statusId);
        }

        public override void ReviewBook(string CustomerId, string statusId)
        {
            DataRepo.AddEvent(new Review(CustomerId, statusId));
        }

    }
}
