using Presentations.Model.API;
using Services.API;
using System;
using System.Collections.Generic;

namespace Presentations.Model.Implementation
{
    internal class StatusModelOperations: IStatusModelOperations
    {

        public StatusModelOperations()
        {
            services = IServices.Create("");
        }

        private IServices services;

        public void AddStatus(string statusId, string bookId, bool availability)
        {
            services.AddStatus(statusId, bookId, availability);
        }

        public void DeleteStatus(string statusId)
        {
            services.DeleteStatus(statusId);
        }

        public IEnumerable<StatusModel> GetAllStatuses()
        {
            var statuses = services.GetAllStatuses();
            var statusModels = new List<StatusModel>();

            foreach (var status in statuses)
            {
                statusModels.Add(new StatusModel(status.Id, status.Book.Id, status.Availability));
            }

            return statusModels;
        }

        public void UpdateStatus(string statusId, string bookId, bool availability)
        {
            services.UpdateStatus(statusId, bookId, availability);
        }
    }
}

