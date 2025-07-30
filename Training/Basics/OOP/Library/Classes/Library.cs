using Basics.OOP.General.Interfaces;
using Basics.OOP.Library.Interface;
namespace Basics.OOP.Library.Classes;
public class Library(List<Book>? books) : ISearchable, IPrintable
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
    public void PrintInfo() => PrintAllBooks();
}