using Data.API;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LogicTest")]

namespace Logic.API
{
    public abstract class IBussinesLogic
    {
        public abstract void BuyBook(string id,string CustomerId, string StatusId);

        public abstract void ReturnBook(string id, string CustomerId, string StatusId);

        public abstract void ReviewBook(string id, string CustomerId, string StatusId, string description);

        public abstract void Complaint(string id, string CustomerId, string StatusId, string Reason);

    }
}
