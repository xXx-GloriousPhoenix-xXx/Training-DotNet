using Basics.OOP.Classes;
using System.Text.Json;
namespace Basics.OOP.Services;
public static class LibraryHandler
{
    public static async Task SaveToFileAsync(this Library library, string path)
    {
        await using var fs = File.Create(path);
        await JsonSerializer.SerializeAsync(fs, library);
    }
    public static async Task<Library?> LoadFromFile(string path)
    {
        await using var fs = File.OpenRead(path);
        return await JsonSerializer.DeserializeAsync<Library>(fs);
    }
    public static List<Book> Filter(this Library library, Func<Book, bool> filter)
    {
        return library.Books.Values.SelectMany(list => list).Where(filter).ToList();
    }

}