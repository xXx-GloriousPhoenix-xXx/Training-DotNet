using Basics.OOP.Interfaces;
namespace Basics.OOP.Classes;

public class Book(string title, string author, ushort? year) : IReadable, IPrintable
{
    public string Title { get; set; } = title;
    public string Author { get; set; } = author;
    public ushort? Year { get; set; } = year;
    public Book(string title) : this(title, "Unknown", null) { }
    public void ReadCover()
    {
        Console.WriteLine($"{Title}, {Author}, {Year}");
    }
    public void PrintInfo() => ReadCover();
}
