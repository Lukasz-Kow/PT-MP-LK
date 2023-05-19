using Data.API;


namespace Data.Implementation;
internal class BookDTO: IBook
{
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string Id { get; set; } = null!;
    public int Pages { get; set; } = 0;
    public string ISBN { get; set; } = null!;
    public string Publisher { get; set; } = null!;
    public string Language { get; set; } = null!;
    
}