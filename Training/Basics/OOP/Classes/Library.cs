using Basics.OOP.Interfaces;
namespace Basics.OOP.Classes;
public class Library(Dictionary<string, List<Book>>? books) : ILibrarySearchable, IPrintable, ILibraryOperatable, ILibrarySerializable
{
    public Dictionary<string, List<Book>> Books { get; set; } = books ?? [];
    public HashSet<string> Authors { get; set; } = books?.Values.SelectMany(list => list).Where(b => b.Author != null).Select(b => b.Author).ToHashSet() ?? [];
    public void AddBook(Book book)
    {
        if (Books.TryGetValue(book.Author, out List<Book>? value))
        {
            value.Add(book);
        }
        else
        {
            Books.Add(book.Author, [book]);
        }
    }
    public void RemoveBook(string author, string title)
    {
        Books[author].RemoveAll(b => b.Title != title);
    }
    public void RemoveAllBooksByAuthor(string author)
    {
        Books.Remove(author);
    }
    public void RemoveAllBooksWithTitle(string title)
    {
        foreach (var pair in Books)
        {
            pair.Value.RemoveAll(b => b.Title == title);
        }
    }
    public IEnumerable<Book> FindAllBooksByTitle(string title)
    {
        return Books
            .Values
            .SelectMany(list => list)
            .Where(b => b.Title == title);
    }
    public IEnumerable<Book> FindAllBooksByAuthor(string author)
    {
        return Books[author];
    }
    public IEnumerable<Book> FindAllBooksByYear(ushort? year)
    {
        return Books
            .Values
            .SelectMany(list => list)
            .Where(b => b.Year == year);
    }
    public Book? FindBook(string title, string author, ushort? year)
    {
        return Books[author]
            .FirstOrDefault(b => 
                b.Title == title && 
                b.Year == year
            );
    }
    public void SaveToFile(string path)
    {
        throw new NotImplementedException();
    }
    public void LoadFromFile(string path)
    {
        throw new NotImplementedException();
    }
    public void PrintInfo()
    {
        foreach (var pair in Books)
        {
            foreach (var book in pair.Value)
            {
                book.ReadCover();
            }
        }
    }
}