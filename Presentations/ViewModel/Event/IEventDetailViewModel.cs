using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentations.ViewModel
{
    public interface IEventDetailViewModel
    {
        ICommand UpdateEvent { get; set; }
        string Id { get; set; }
        string StatusId { get; set; }
        string CustomerId { get; set; }
        DateTime EventDate { get; set; }
        string Type { get; set; }
        string ReasonOrDescription { get; set; }
    }
}
