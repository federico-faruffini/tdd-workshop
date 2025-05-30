namespace WordCounter;

public class WordCounter
{
    public int CountWords(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return 0;
        }

        var words = input.Split(' ');
        return words.Length;
    }
}
