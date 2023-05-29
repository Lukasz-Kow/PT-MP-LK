using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentations.Model
{
    public interface IEventModel
    {
        string Id { get; set; }
        string StatusId { get; set; }
        string CustomerId { get; set; }
        DateTime Time { get; set; }
        
    }
}
