internal class Program
{
    const int FROM = 11098;
    const int TO = 98123;

    private static bool IsValidCombination(string combination)
    {
        if (combination.Count(x => x == '5') < 2 )
            return false;

        for (int i = 0; i < combination.Length - 1; i++)
        {
            if (combination[i] > combination[i +1])
                return false;
        }

        return true;
    }
    
    private static void Main(string[] args)
    {
        var combinations = Enumerable.Range(FROM, TO).Where(x => IsValidCombination(x.ToString()));
        Console.WriteLine($"Total valid combinations: {combinations.Count()}");
        Console.WriteLine($"Index 55 combination: {combinations.ElementAt(55)}");
    }
}