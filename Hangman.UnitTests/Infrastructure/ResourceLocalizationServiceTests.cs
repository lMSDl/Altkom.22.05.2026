using AutoFixture;
using Hangman.Application;
using Hangman.Infrastructure;

namespace Hangman.UnitTests.Infrastructure;

public class ResourceLocalizationServiceTests
{
    private readonly Fixture _fixture = new();
    private readonly ResourceLocalizationService _sut = new();

    [Fact]
    public void Get_EnglishLanguage_ReturnsNonNullString()
    {
        // Arrange
        var key = _fixture.Create<string>();

        // Act
        var result = _sut.Get(key, GameLanguage.English);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void Get_PolishLanguage_ReturnsNonNullString()
    {
        // Arrange
        var key = _fixture.Create<string>();

        // Act
        var result = _sut.Get(key, GameLanguage.Polish);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void Get_KeyNotFoundInResources_ReturnsKey()
    {
        // Arrange - use a key that is highly unlikely to exist in resources
        var key = _fixture.Create<string>();

        // Act
        var result = _sut.Get(key, GameLanguage.English);

        // Assert - fallback: when resource is missing, key is returned as-is
        Assert.Equal(key, result);
    }

    [Fact]
    public void Get_KeyNotFoundInResourcesPolish_ReturnsKey()
    {
        // Arrange
        var key = _fixture.Create<string>();

        // Act
        var result = _sut.Get(key, GameLanguage.Polish);

        // Assert
        Assert.Equal(key, result);
    }

    [Theory]
    [InlineData(GameLanguage.English)]
    [InlineData(GameLanguage.Polish)]
    public void Get_AnyLanguage_NeverReturnsNull(GameLanguage language)
    {
        // Arrange
        var key = _fixture.Create<string>();

        // Act
        var result = _sut.Get(key, language);

        // Assert
        Assert.NotNull(result);
    }

    [Theory]
    [InlineData(GameLanguage.English)]
    [InlineData(GameLanguage.Polish)]
    public void Get_UnknownKey_ReturnsSameKey(GameLanguage language)
    {
        // Arrange - GUID-based key won't exist in any resource file
        var key = Guid.NewGuid().ToString("N");

        // Act
        var result = _sut.Get(key, language);

        // Assert
        Assert.Equal(key, result);
    }

    [Fact]
    public void Get_SameKeyDifferentLanguages_ReturnsSameKeyWhenNotInResources()
    {
        // Arrange
        var key = Guid.NewGuid().ToString("N");

        // Act
        var englishResult = _sut.Get(key, GameLanguage.English);
        var polishResult = _sut.Get(key, GameLanguage.Polish);

        // Assert - both should return the key as fallback
        Assert.Equal(key, englishResult);
        Assert.Equal(key, polishResult);
    }
}
