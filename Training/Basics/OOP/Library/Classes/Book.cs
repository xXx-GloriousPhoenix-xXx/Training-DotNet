using Basics.OOP.General.Interfaces;
using Basics.OOP.Library.Interface;
namespace Basics.OOP.Library.Classes;

public class Book(string title, string author, ushort year) : IReadable, IPrintable
{
    public string Title { get; set; } = title;
    public string Author { get; set; } = author;
    public ushort Year { get; set; } = year;
    public void ReadCover()
    {
        Console.WriteLine($"{Title}, {Author}, {Year}");
    }
    public void PrintInfo() => ReadCover();
}
