namespace Data;

public class Book
{
    private int _id;
    private string _title;
    private string _author;
    private string _publisher;
    private string _isbn;
    private Genres _genre;
    private int _year;
    private int _pages;
    private int _price;
    
    public int Id
    {
        get => _id;
        set => _id = value;
    }
    
    public string Title
    {
        get => _title;
        set => _title = value;
    }
    
    public string Author
    {
        get => _author;
        set => _author = value;
    }
    
    public string Publisher
    {
        get => _publisher;
        set => _publisher = value;
    }
    
    public string Isbn
    {
        get => _isbn;
        set => _isbn = value;
    }
    
    public Genres Genre
    {
        get => _genre;
        set => _genre = value;
    }
    
    public int Year
    {
        get => _year;
        set => _year = value;
    }
    
    public int Pages
    {
        get => _pages;
        set => _pages = value;
    }
    
    public int Price
    {
        get => _price;
        set => _price = value;
    }
    
public Book(int id, string title, string author, string publisher, string isbn, Genres genre, int year, int pages, int price)
    {
        _id = id;
        _title = title;
        _author = author;
        _publisher = publisher;
        _isbn = isbn;
        _genre = genre;
        _year = year;
        _pages = pages;
        _price = price;
    }
    
}