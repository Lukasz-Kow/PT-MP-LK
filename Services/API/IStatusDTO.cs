namespace Services.API;

public interface IStatusDTO
{
    public string BookId { get; set; }
    
    string Id { get; set; }
    
    bool Availability { get; set; }
}