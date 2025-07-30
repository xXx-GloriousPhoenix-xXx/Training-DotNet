using Basics.OOP.Classes;

namespace Basics.OOP.Interfaces;
public interface ISearchable
{
    Book? FindBookByTitle(string title);
    Book? FindBookByAuthor(string author);
}
