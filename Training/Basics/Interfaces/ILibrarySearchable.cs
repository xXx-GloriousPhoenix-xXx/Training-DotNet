using Basics.Classes;

namespace Basics.Interfaces;
public interface ILibrarySearchable
{
    IEnumerable<Book> FindAllBooksByTitle(string title);
    IEnumerable<Book> FindAllBooksByAuthor(string author);
    IEnumerable<Book> FindAllBooksByYear(ushort? year);
    Book? FindBook(string title, string author, ushort? year);
}
