internal class Program
{
    const string ENCRYPTED = "11610497110107115 102111114 11210897121105110103 9911110010110998101114 11210810197115101 11510497114101";

    private static bool IsValidAsciiRange(string input)
    {
        int val = int.Parse(input);
        return val >= 65 && val <= 122;
    }

    private static List<string> SplitLetters(string input)
    {
        var result = new List<string>();
        string word = "";

        for (int i = 0; i < input.Length; i++)
        {
            word += input[i];
            if (IsValidAsciiRange(word))
            {
                result.Add(word);
                word= "";
            }
        }

        return result;
    }

    private static char GetCharFromAsciiCode(string input)
    {
        int ascii = int.Parse(input);
        return Convert.ToChar(ascii);

    }

    private static string DecryptWord(string encryptedWord)
    {
        var letters = SplitLetters(encryptedWord).Select(GetCharFromAsciiCode);
        return string.Join("", letters);
    }

    private static async Task Main(string[] args)
    {
        var words = ENCRYPTED.Split(' ');
        var decryptedWords = words.Select(DecryptWord);
        Console.WriteLine(string.Join(" ", decryptedWords));
    }
}