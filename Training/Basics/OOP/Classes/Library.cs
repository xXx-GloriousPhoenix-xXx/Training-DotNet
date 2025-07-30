using Basics.OOP.Interfaces;
namespace Basics.OOP.Classes;
public class Book(string title, string author, ushort year) : IReadable
{
    public string Title { get; set; } = title;
    public string Author { get; set; } = author;
    public ushort Year { get; set; } = year;
    public void ReadCover()
    {
        Console.WriteLine($"{Title}, {Author}, {Year}");
    }
}
public class Library(List<Book>? books) : ISearchable
{
    public List<Book> Books { get; set; } = books ?? [];
    public void AddBook(Book book)
    {
        Books.Add(book);
    }
    public void RemoveBook(string title)
    {
        Books = Books.Where(b => b.Title != title).ToList();
    }
    public void PrintAllBooks()
    {
        foreach (var book in Books)
        {
            book.ReadCover();
        }
    }
    public Book? FindBookByTitle(string title)
    {
        return Books.FirstOrDefault(b => b.Title == title);
    }
    public Book? FindBookByAuthor(string author)
    {
        return Books.FirstOrDefault(b => b.Author == author);
    }
}