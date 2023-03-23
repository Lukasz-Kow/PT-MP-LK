namespace Data;

public class Book : ILibraryItem
{
    protected int id;
    private string title;
    private string author;
    private int pageNumber;
    private Category category;
    private string description;

    public int Id
    {
        get => id;
        set { id = value; }
    }

    public string Title
    {
        get => title;
        set { title = value; }
    }

    public string Author
    {
        get => author;
        set { author = value; }
    }
    
    public int PageNumber
    {
        get => pageNumber;
        set { pageNumber = value; }
    }
    
    public Category Category
    {
        get => category;
        set { category = value; }
    }
    
    public string Description
    {
        get => description;
        set { description = value; }
    }


    // constructor
    public Book (int id, string title, string author, int pageNumber, Category category, string description)
    {
        this.id = id;
        this.title = title;
        this.author = author;
        this.pageNumber = pageNumber;
        this.category = category;
        this.description = description;
    }
    
    // getters and setters

    
    
    

}