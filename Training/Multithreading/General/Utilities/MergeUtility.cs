namespace Multithreading.General.Utilities;
public static class MergeUtility
{
    public static void MergeAllFiles(string destinationPath = "../../../Utilities/Result/MergeResult.txt")
    {
        var dirs = Directory.GetDirectories("../../../")
            .Where(d => !d.Contains("bin") && !d.Contains("obj") && !d.Contains(".vs"));
        using var sw = new StreamWriter(destinationPath);
        foreach (var dir in dirs)
        {
            foreach (var file in Directory.GetFiles(dir))
            {
                using var sr = new StreamReader(file);
                sw.Write(sr.ReadToEnd());
            }
        }
    }
}