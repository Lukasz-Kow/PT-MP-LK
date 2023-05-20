using Data.API;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Implementation;

internal class StatusDTO: IStatus
{
    
    [ForeignKey(nameof(Book))]
    public IBook Book { get; set; }
    public string Id { get; set; }
    public bool Availability { get; set; }
}