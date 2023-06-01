
using Presentations.Model.Implementation;
using System;
using System.Collections.Generic;

namespace Presentations.Model.API
{
    interface IEventModelOperations
    {
        static IEventModelOperations CreateModelOperation()
        {
            return new EventModelOperations();
        }

        public void AddEvent(string Id, string statusId, string customerId, DateTime Time, string type, string? descriptionOrReason);
        public void DeleteEvent(string Id);
        public void UpdateEvent(string Id, string statusId, string customerId, DateTime Time, string type, string? descriptionOrReason);
        public IEnumerable<IEventModel> GetAllEvents();

    }
}
