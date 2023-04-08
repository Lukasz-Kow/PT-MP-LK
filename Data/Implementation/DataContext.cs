using Data.API;

namespace Data.Implementation;

internal class DataContext : IDataContext
{
    internal Dictionary<string, IBook> Books = new();
    internal List<IEvent> Events = new();
    internal List<IStatus> States = new();
    internal List<ICustomer> Customers = new();
}