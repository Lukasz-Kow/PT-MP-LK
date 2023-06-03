using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentations.Model.API
{
    public interface IStatusModel
    {
        public string BookId { get; set; }

        public string Id { get; set; }
        public bool Availability { get; set; }
    }
}
