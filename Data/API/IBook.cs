namespace Data.API;

public interface IBook
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Id { get; set; }
    
    public string Pages { get; set; }
    
    public string ISBN { get; set; }
    
    public string Publisher { get; set; }
    
    public string Language { get; set; }
    
}