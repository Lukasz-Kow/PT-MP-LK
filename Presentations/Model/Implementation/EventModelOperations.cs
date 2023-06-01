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

        private IEventModel Map(IEventDTO even)
        {
            return new EventModel(even.Id, even.StatusId, even.CustomerId, even.Time, even.Type, even.ReasonOrDescription);
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
                eventModels.Add(Map(ev));
            }

            return eventModels;
        }

        public void UpdateEvent(string Id, string statusId, string customerId, DateTime Time, string type, string? descriptionOrReason)
        {
            throw new NotImplementedException();
        }
    }
}
