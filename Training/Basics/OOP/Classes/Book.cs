using Basics.OOP.Interfaces;
using System.Text.Json.Serialization;
namespace Basics.OOP.Classes;

public class Book : IReadable, IPrintable
{
    public string Title { get; set; }
    public string Author { get; set; } 
    public ushort? Year { get; set; }
    [JsonConstructor]
    public Book(string title, string author, ushort? year)
    {
        Title = title;
        Author = author;
        Year = year;
    }
    public Book(string title) : this(title, "Unknown", null) { }
    public void ReadCover()
    {
        Console.WriteLine($"{Title}, {Author}, {Year}");
    }
    public void PrintInfo() => ReadCover();
}
