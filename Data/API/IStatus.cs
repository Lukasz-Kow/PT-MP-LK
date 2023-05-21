namespace Data.API;

public interface IStatus
{
    public IBook Book { get; set; }
    
    string Id { get; }
    
    bool Availability { get; set; }
}