using Services.API;
using System;
using System.Collections.Generic;
using Presentations.Model.API;

namespace Presentations.Model.Implementation
{
    internal class EventModelOperations: IEventModelOperations
    {
        private readonly IServices services;

        public EventModelOperations()
        {
            services = IServices.Create("");
        }

        public void AddEvent(string Id, string statusId, string customerId, DateTime Time, string type, string? descriptionOrReason)
        {
            if (type == "Buy")
            {
                services.AddBuy(Id, statusId, customerId, Time);
            } 
            else if (type == "Complaint")
            {
                services.AddComplaint(Id, statusId, customerId, Time, descriptionOrReason);
            } 
            else if (type == "Review")
            {
                services.AddReview(Id, statusId, customerId, Time, descriptionOrReason);
            } 
            else if (type == "Return")
            {
                services.AddReturn(Id, statusId, customerId, Time);
            }
        }

        public void DeleteEvent(string eventId)
        {
            services.DeleteEvent(eventId);
        }

        public IEnumerable<IEventModel> GetAllEvents()
        {
            var events = services.GetAllEvents();
            var eventModels = new List<IEventModel>();

            foreach (var ev in events)
            {
                if (ev is BuyModel buy)
                {
                    eventModels.Add(new BuyModel(buy.Id, buy.StatusId, buy.CustomerId, buy.Time));
                }
                else if (ev is ComplaintModel complaintModel)
                {
                    eventModels.Add(new ComplaintModel(complaintModel.Id, complaintModel.StatusId, complaintModel.CustomerId, complaintModel.Time, complaintModel.Reason));
                }
                else if (ev is ReviewModel rev)
                {
                    eventModels.Add(new ReviewModel(rev.Id, rev.StatusId, rev.CustomerId, rev.Time, rev.Description));
                }
                else if (ev is ReturnModel ret)
                {
                    eventModels.Add(new ReturnModel(ret.Id, ret.StatusId, ret.CustomerId, ret.Time));
                }
                
            }

            return eventModels;
        }
    }
}
