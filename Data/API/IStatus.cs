namespace Data.API;

public interface IStatus
{
    public IBook Book { get; set; }
    
    string Id { get; set; }
    
    bool Availability { get; set; }
}