using Basics.OOP.Classes;
namespace Basics.OOP.Interfaces;
public interface ILibraryOperatable
{
    public void AddBook(Book book);
    public void RemoveBook(string author, string title);
    public void RemoveAllBooksByAuthor(string author);
    public void RemoveAllBooksWithTitle(string title);
}
