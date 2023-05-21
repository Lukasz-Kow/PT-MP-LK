namespace Data.API;

public interface IBook
{
    public string Title { get; }
    public string Author { get; }
    public string Id { get; }
    
    public int Pages { get; }
    
    public string ISBN { get; }
    
    public string Publisher { get; }
    
    public string Language { get; }
    
}