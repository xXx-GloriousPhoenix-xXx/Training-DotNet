namespace Basics.OOP.Interfaces;

public interface ILibrarySerializable
{
    public void SaveToFile(string path);
    public void LoadFromFile(string path);
}
