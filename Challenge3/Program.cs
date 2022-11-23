using System.Text.Json;

internal class Program
{
    const string FILENAME = "colors.txt";
    private static List<string> LongestSequence = new List<string>();
    private static async Task<string[]> GetColors()
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), FILENAME);
        var fileContent = await File.ReadAllTextAsync(path);
        return JsonSerializer.Deserialize<string[]>(fileContent);
    }

    private static void ResetSequence(List<string> list)
    {
        var lastElement = list.Last();
        var previousLastElement = list.ElementAt(new Index(2, true));
        var listToSave = lastElement.Equals(previousLastElement) ? new List<string> { lastElement } : list.ToList();

        if (listToSave.Count >= LongestSequence.Count)
            LongestSequence = listToSave;

        list.Clear();
        list.Add(lastElement);
    }

    private static void EvaluateElement(List<string> list, string element)
    {
        var previousLastElement = list.ElementAt(new Index(2, true));
        if (!previousLastElement.Equals(element))
            ResetSequence(list);

        list.Add(element);
    }

    private static async Task Main(string[] args)
    {
        var colors = await GetColors();
        var list = new List<string> { colors[0], colors[1] };

        for (int i = 2; i < colors.Length; i++)
        {
            var color = colors[i];
            EvaluateElement(list, color);
        }

        Console.WriteLine($"Longest Sequence Count: {LongestSequence.Count}");
        Console.WriteLine($"Last Sequence Color: {LongestSequence.Last()}");
    }
}