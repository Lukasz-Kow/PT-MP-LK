namespace Data.API;

public interface IStatus
{
    IBook Book { get; set; }
    
    string StatusId { get; set; }
    
    bool Availability { get; set; }
}