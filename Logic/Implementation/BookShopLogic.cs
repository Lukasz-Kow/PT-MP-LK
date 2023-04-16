using Data.API;
using Logic.API;

namespace Logic.Implementation
{
    internal class BookShopLogic : IBookShopLogic
    {
        private IDataRepository DataRepo;

        public BookShopLogic(IDataRepository dataRepo)
        {
            DataRepo = dataRepo;
        }

        public void BuyBook(string id, string customerId, string statusId)
        {
            if (!DataRepo.IsAvailable(statusId)) throw new InvalidOperationException("This book has already been purchased.");
            IBuy buy = new Buy(id,statusId, customerId);
            DataRepo.AddEvent(buy);
            DataRepo.ChangeAvailability(statusId);
        }

        public void ReturnBook(string id, string customerId, string statusId)
        {
            if (DataRepo.IsAvailable(statusId)) throw new InvalidOperationException("Can't return this book, it's available now");
            DataRepo.AddEvent(new Return(id, statusId, customerId));
            DataRepo.ChangeAvailability(statusId);
        }

        public void ReviewBook(string id,string CustomerId, string statusId, string description)
        {
            DataRepo.AddEvent(new Review(id, CustomerId, statusId, description));
        }

        public void Complaint(string id, string CustomerId, string statusId, string Reason)
        {
            DataRepo.AddEvent(new Complaint(id, CustomerId,statusId, Reason));
        }

    }
}
