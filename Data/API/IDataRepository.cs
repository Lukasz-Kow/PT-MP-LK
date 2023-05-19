using Data.Implementation;

namespace Data.API;

public interface IDataRepository
{

 public static IDataRepository CDataRepository()
 {
  return new DataRepository();
 }

}