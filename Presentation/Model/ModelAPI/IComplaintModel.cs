
using System.Threading.Tasks;
using System;
using Data.API;

namespace Presentation.Model.ModelAPI
{
    public interface IComplaintModel
    {
        string Id { get; set; }
        public string StatusId { get; set; }

        public string CustomerId { get; set; }

        DateTime Time { get; set; }

        string Reason { get; set; }

        public void AddComplaint(string Id, IStatus status, ICustomer customer, DateTime Time, string Reason);


    }
}
