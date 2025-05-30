namespace WordCounter;

public class WordCounterTests
{
    [Fact]
    public void GivenTheStringIsNull_WhenCountWords_ThenReturnsZero()
    {
        // Arrange
        string? input = null;
        var wordCounter = new WordCounter();

        // Act
        var result = wordCounter.CountWords(input);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GivenTheStringIsEmpty_WhenCountWords_ThenReturnsZero()
    {
        // Arrange
        string input = "";
        var wordCounter = new WordCounter();

        // Act
        var result = wordCounter.CountWords(input);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void GivenTwoWordsInTheString_WhenCountWords_ThenReturnsTwo()
    {
        // Arrange
        string input = "one two";
        var wordCounter = new WordCounter();

        // Act
        var result = wordCounter.CountWords(input);

        // Assert
        Assert.Equal(2, result);
    }
    
    
    public void GivenTwoWordsInTheStringSeparatedByThreeSpaces_WhenCountWords_ThenReturnsTwo()
    {
        // Arrange
        string input = "one   two";
        var wordCounter = new WordCounter();

        // Act
        var result = wordCounter.CountWords(input);

        // Assert
        Assert.Equal(2, result);
    }
}
