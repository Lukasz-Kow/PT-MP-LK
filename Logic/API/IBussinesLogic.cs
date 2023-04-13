using Data.API;
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
        public abstract void BuyBook(string CustomerId, string statusId);

        public abstract void ReturnBook(string CustomerId, string statusId);

        public abstract void ReviewBook(string CustomerId, string statusId);

    }
}
