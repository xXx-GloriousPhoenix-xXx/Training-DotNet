using Basics.Exceptions;
using Basics.Interfaces;
namespace Basics.Classes;
public class Library : ILibrarySearchable, IPrintable, ILibraryOperatable
{
    public Dictionary<string, List<Book>> Books { get; set; } = []; //Author: List<Book>
    public Library() { }
    public Library(Dictionary<string, List<Book>> books) => Books = books;
    public Library(List<Book> books) : this(
        books
            .GroupBy(b => b.Author)
            .ToDictionary(g => g.Key, g => g.ToList())
    )
    { }
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
        if (Books.TryGetValue(author, out List<Book>? books))
        {
            Books.Remove(author);
        }
        else
        {
            throw new AuthorNotFoundException($"Books with author \"{author}\" not found");
        }
    }
    public void RemoveAllBooksWithTitle(string title)
    {
        var containFlag = false;
        foreach (var pair in Books)
        {
            if (pair.Value.Any(b => b.Title == title))
            {
                pair.Value.RemoveAll(b => b.Title == title);
                containFlag = true;
            }
        }
        if (!containFlag)
        {
            throw new TitleNotFoundException($"Books with title \"{title}\" not found");
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
    public List<Book> Filter(Func<Book, bool> filter)
    {
        return Books.Values.SelectMany(list => list).Where(filter).ToList();
    }
    public void PrintInfo()
    {
        foreach (var pair in Books)
        {
            Console.WriteLine(pair.Key);
            foreach (var book in pair.Value)
            {
                Console.WriteLine($" - \"{book.Title}\", {book.Year}");
            }
        }
    }
    public List<Book> FilterParallel(Func<Book, bool> filter)
    {
        return Books
            .Values
            .AsParallel()
            .SelectMany(list => list)
            .Where(filter)
            .ToList();
    }
}
