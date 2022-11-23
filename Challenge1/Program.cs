using System.Text.RegularExpressions;

internal class Program
{
    const string FILENAME = "users.txt";

    private static async Task<List<string>> GetPeopleLines()
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), FILENAME);
        var fileContent = await File.ReadAllTextAsync(path);
        var people = fileContent.Split("\n\n", StringSplitOptions.RemoveEmptyEntries).ToList();
        return people.Select(x => x.Replace("\n", " ").Trim()).ToList();
    }

    private static bool isValidPerson(string person)
    {
        string[] requiredFields = new string[] { "usr", "eme", "psw", "age", "loc", "fll" };
        return requiredFields.All(x =>
        {
            string pattern = @$"\b{x}:";
            return Regex.IsMatch(person, pattern);
        });

    }

    private static async Task Main(string[] args)
    {
        var people = await GetPeopleLines();
        var validPeople = people.Where(isValidPerson);
        var lastPerson = validPeople.LastOrDefault();
        Console.WriteLine($"{validPeople.Count()} - {lastPerson}");
    }
}