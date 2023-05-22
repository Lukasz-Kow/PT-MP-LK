using Data.Implementation;
using System.Data.Linq;

namespace Data.API;

public interface IDataRepository
{

    public static IDataRepository CDataRepository(string connectStr)
    {
        return new DataRepository(connectStr);
    }

    public ICustomer GetCustomer(int id);

    public void InsertCustomer(ICustomer customer);

    public void UpdateCustomer(ICustomer updatedCustomer);
}