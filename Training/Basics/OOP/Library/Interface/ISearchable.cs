using Basics.OOP.Library.Classes;

namespace Basics.OOP.Library.Interface;
public interface ISearchable
{
    Book? FindBookByTitle(string title);
    Book? FindBookByAuthor(string author);
}
