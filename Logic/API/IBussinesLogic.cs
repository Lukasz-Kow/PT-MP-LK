using Data.API;
using Logic.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Logic.API
{
    public abstract class IBussinesLogic
    {
        public abstract void BuyBook(string CustomerId, string StatusId);

        public abstract void ReturnBook(string CustomerId, string StatusId);

        public abstract void ReviewBook(string CustomerId, string StatusId);

        public abstract void Complaint(string CustomerId, string StatusId, string Reason);

        public static IBussinesLogic CreateLogic(IDataRepository? dataRepository = default)
        {
            return new BussinesLogic(dataRepository ?? IDataRepository.CDataRepository());
        }

    }
}
