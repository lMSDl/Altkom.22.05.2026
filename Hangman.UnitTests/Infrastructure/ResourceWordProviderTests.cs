using AutoFixture;
using Hangman.Application;
using Hangman.Infrastructure;

namespace Hangman.UnitTests.Infrastructure;

public class ResourceWordProviderTests
{
    private readonly Fixture _fixture = new();
    private readonly ResourceWordProvider _sut = new();

    [Fact]
    public void GetRandomWord_EnglishLanguage_ReturnsNonNullString()
    {
        // Act
        var result = _sut.GetRandomWord(GameLanguage.English);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void GetRandomWord_EnglishLanguage_ReturnsNonEmptyString()
    {
        // Act
        var result = _sut.GetRandomWord(GameLanguage.English);

        // Assert
        Assert.NotEmpty(result);
    }

    [Fact]
    public void GetRandomWord_PolishLanguage_ReturnsNonNullString()
    {
        // Act
        var result = _sut.GetRandomWord(GameLanguage.Polish);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void GetRandomWord_PolishLanguage_ReturnsNonEmptyString()
    {
        // Act
        var result = _sut.GetRandomWord(GameLanguage.Polish);

        // Assert
        Assert.NotEmpty(result);
    }

    [Fact]
    public void GetRandomWord_EnglishLanguage_ReturnedWordContainsNoSemicolon()
    {
        // Act
        var result = _sut.GetRandomWord(GameLanguage.English);

        // Assert
        Assert.DoesNotContain(';', result);
    }

    [Fact]
    public void GetRandomWord_PolishLanguage_ReturnedWordContainsNoSemicolon()
    {
        // Act
        var result = _sut.GetRandomWord(GameLanguage.Polish);

        // Assert
        Assert.DoesNotContain(';', result);
    }

    [Theory]
    [InlineData(GameLanguage.English)]
    [InlineData(GameLanguage.Polish)]
    public void GetRandomWord_CalledMultipleTimes_DoesNotThrow(GameLanguage language)
    {
        // Act & Assert
        for (var i = 0; i < 10; i++)
        {
            var result = _sut.GetRandomWord(language);
            Assert.NotNull(result);
        }
    }
}
