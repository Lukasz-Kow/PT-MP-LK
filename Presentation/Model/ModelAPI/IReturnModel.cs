    
using System.Threading.Tasks;
using System;

namespace Presentation.Model.ModelAPI
{
    public interface IReturnModel
    {
        string Id { get; set; }
        public string StatusId { get; set; }

        public string CustomerId { get; set; }

        DateTime Time { get; set; }

        Task AddAsync();

    }
}
