using Data.API;
using System.Runtime.CompilerServices;
using Logic.Implementation;

[assembly: InternalsVisibleTo("LogicTest")]

namespace Logic.API
{
    public interface IBookShopLogic
    {
        public void BuyBook(string id,string CustomerId, string StatusId);

        public void ReturnBook(string id, string CustomerId, string StatusId);

        public void ReviewBook(string id, string CustomerId, string StatusId, string description);

        public void Complaint(string id, string CustomerId, string StatusId, string Reason);
        
        public static IBookShopLogic CreateBookShopLogic(IDataRepository dataRepo)
        {
            return new BookShopLogic(dataRepo);
        }

    }
}
