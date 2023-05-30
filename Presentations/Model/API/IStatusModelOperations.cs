using Presentations.Model.Implementation;
using System.Collections.Generic;

namespace Presentations.Model.API
{
    interface IStatusModelOperations
    {
        static IStatusModelOperations CreateModelOperation()
        {
            return new StatusModelOperations();
        }

        public void AddStatus(string statusId, string bookId, bool availability);
        public void DeleteStatus(string statusId);
        public void UpdateStatus(string statusId, string bookId, bool availability);
        public IEnumerable<StatusModel> GetAllStatuses();
    }
}
