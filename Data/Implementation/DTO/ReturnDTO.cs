using Data.API;

namespace Data.Implementation;

internal class ReturnDTO: IReturn
{
    public string Id { get; set; }

    public IStatus Status{ get; set;}

    public ICustomer Customer { get; set; }
    public DateTime Time { get; set; }
}