namespace Multithreading.Tasks.Task_3;
public static class Task_3
{
    public static void Test()
    {     
        var fileQuantity = 10;
        var fileDataList = Enumerable.Range(1, fileQuantity).Select(index =>
        {
            var path = $"../../../Tasks/Task_3/Data/File_{index}.txt";
            File.Create(path);
            return new FileData(path);
        });
        var processor = new FileProcessor(3);
        processor.Execute(fileDataList);
    }
}
public class FileData(string path)
{
    public string Path { get; set; } = path;
}
public class FileProcessor(int maxConcurrency)
{
    public int MaxConcurrency { get; set; } = maxConcurrency;
    public void Execute(IEnumerable<FileData> fileDataList)
    {
        Parallel.ForEach(
            fileDataList, 
            new ParallelOptions
            {
                MaxDegreeOfParallelism = MaxConcurrency
            },
            file =>
            {
                var lines = ProcessFile(file);
                Console.WriteLine(lines);
            }
        );
    }
    public static int ProcessFile(FileData fileData)
    {
        return File.ReadAllLinesAsync(fileData.Path).Result.Length;
    }
}
