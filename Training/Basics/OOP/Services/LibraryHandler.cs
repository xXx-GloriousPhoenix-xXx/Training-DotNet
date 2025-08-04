using Basics.OOP.Classes;
using System.Text.Json;
using Basics.OOP.Exceptions;
namespace Basics.OOP.Services;
public static class LibraryHandler
{
    public static void SaveToFile(this Library library, string path = "../../../OOP/Data/LibraryWrite/Library.json")
    {
        try
        {
            using var fs = File.Create(path);
            JsonSerializer.SerializeAsync(fs, library);
        }
        catch (Exception e)
        {
            throw new LibrarySavingException(e.Message);
        }
    }
    public static async Task SaveToFileAsync(this Library library, string path = "../../../OOP/Data/LibraryWrite/Library.json")
    {
        try
        {
            await using var fs = File.Create(path);
            await JsonSerializer.SerializeAsync(fs, library);
        }
        catch (Exception e)
        {
            throw new LibrarySavingException(e.Message);
        }
    }
    public static Library? LoadFromFile(string path = "../../../OOP/Data/LibraryRead/Library.json")
    {
        try
        {
            using var fs = File.OpenRead(path);
            return JsonSerializer.Deserialize<Library>(fs);
        }
        catch (Exception e)
        {
            throw new LibraryLoadingException(e.Message);
        }
    }
    public static async Task<Library?> LoadFromFileAsync(string path = "../../../OOP/Data/LibraryRead/Library.json")
    {
        try
        {
            await using var fs = File.OpenRead(path);
            return await JsonSerializer.DeserializeAsync<Library>(fs);
        }
        catch (Exception e)
        {
            throw new LibraryLoadingException(e.Message);
        }
    }
    public static async Task<List<Library>> LoadAllLibrariesAsync(List<string> paths)
    {
        var libraryTasks = paths.Select(LoadFromFileAsync);
        var libraries = await Task.WhenAll(libraryTasks);
        return libraries.Where(lib => lib is not null).ToList()!;
    }
}