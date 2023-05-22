    
using System.Threading.Tasks;
using System;
using Data.API;

namespace Presentation.Model.ModelAPI
{
    public interface IReturnModel
    {
        string Id { get; set; }
        public string StatusId { get; set; }

        public string CustomerId { get; set; }

        DateTime Time { get; set; }

        public void AddReturn(string Id, IStatus status, ICustomer customer, DateTime Time);

    }
}
