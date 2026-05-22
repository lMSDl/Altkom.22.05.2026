using AutoFixture;
using Hangman.Application;
using Hangman.Domain;
using NSubstitute;

namespace Hangman.UnitTests.Application;

public class StartGameUseCaseTests
{
    private readonly IFixture _fixture = new Fixture();
    private readonly IWordProvider _wordProvider = Substitute.For<IWordProvider>();
    private readonly StartGameUseCase _sut;

    public StartGameUseCaseTests()
    {
        _sut = new StartGameUseCase(_wordProvider);
    }

    [Fact]
    public void Execute_WithLanguageAndDefaultAttempts_ReturnsGameStateWithProviderWord()
    {
        // Arrange
        var language = GameLanguage.English;
        var word = _fixture.Create<string>();
        _wordProvider.GetRandomWord(language).Returns(word);

        // Act
        GameState result = _sut.Execute(language);

        // Assert
        Assert.Equal(word.Trim().ToLowerInvariant(), result.SecretWord);
    }

    [Fact]
    public void Execute_WithLanguageAndDefaultAttempts_CallsWordProviderWithCorrectLanguage()
    {
        // Arrange
        var language = GameLanguage.Polish;
        _wordProvider.GetRandomWord(language).Returns(_fixture.Create<string>());

        // Act
        _sut.Execute(language);

        // Assert
        _wordProvider.Received(1).GetRandomWord(language);
    }

    [Fact]
    public void Execute_WithCustomMaxAttempts_ReturnsGameStateWithCorrectMaxAttempts()
    {
        // Arrange
        var language = GameLanguage.English;
        var maxAttempts = _fixture.Create<int>();
        _wordProvider.GetRandomWord(language).Returns(_fixture.Create<string>());

        // Act
        GameState result = _sut.Execute(language, maxAttempts);

        // Assert
        Assert.Equal(maxAttempts, result.MaxAttempts);
    }

    [Theory]
    [InlineData(GameLanguage.Polish)]
    [InlineData(GameLanguage.English)]
    public void Execute_WithEachLanguage_CallsWordProviderWithThatLanguage(GameLanguage language)
    {
        // Arrange
        _wordProvider.GetRandomWord(language).Returns(_fixture.Create<string>());

        // Act
        _sut.Execute(language);

        // Assert
        _wordProvider.Received(1).GetRandomWord(language);
    }

    [Fact]
    public void Execute_WithDefaultMaxAttempts_ReturnsGameStateWithSixMaxAttempts()
    {
        // Arrange
        var language = GameLanguage.English;
        _wordProvider.GetRandomWord(language).Returns(_fixture.Create<string>());

        // Act
        GameState result = _sut.Execute(language);

        // Assert
        Assert.Equal(6, result.MaxAttempts);
    }

    [Fact]
    public void Execute_ReturnsNonNullGameState()
    {
        // Arrange
        var language = GameLanguage.English;
        _wordProvider.GetRandomWord(language).Returns(_fixture.Create<string>());

        // Act
        GameState result = _sut.Execute(language);

        // Assert
        Assert.NotNull(result);
    }
}
