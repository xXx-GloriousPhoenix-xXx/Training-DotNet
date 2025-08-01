namespace Basics.Utilities;
public static class MergeFiles
{
    public static void Merge(this List<string> directoryPaths, string resultPath = "../../../Utilities/Result/Merged.txt")
    {
        using var sw = new StreamWriter(resultPath);
        foreach (var directoryPath in directoryPaths)
        {
            foreach (var file in Directory.GetFiles(directoryPath))
            {
                using var sr = new StreamReader(file);
                sw.WriteLine(sr.ReadToEnd());
            }
        }
    }
}