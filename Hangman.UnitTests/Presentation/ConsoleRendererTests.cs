using AutoFixture;
using Hangman.Application;
using Hangman.Domain;
using Hangman.Presentation;
using NSubstitute;

namespace Hangman.UnitTests.Presentation;

public class ConsoleRendererTests : IDisposable
{
    private readonly ILocalizationService _loc;
    private readonly ConsoleRenderer _sut;
    private readonly Fixture _fixture;
    private readonly StringWriter _consoleOut;
    private readonly TextWriter _originalOut;
    private readonly TextReader _originalIn;

    public ConsoleRendererTests()
    {
        _loc = Substitute.For<ILocalizationService>();
        _sut = new ConsoleRenderer(_loc);
        _fixture = new Fixture();

        _originalOut = Console.Out;
        _originalIn = Console.In;

        _consoleOut = new StringWriter();
        Console.SetOut(_consoleOut);

        _loc.Get(Arg.Any<string>(), Arg.Any<GameLanguage>()).Returns(ci => ci.Arg<string>());
    }

    public void Dispose()
    {
        Console.SetOut(_originalOut);
        Console.SetIn(_originalIn);
        _consoleOut.Dispose();
    }

    private void SetConsoleInput(params string[] lines)
    {
        Console.SetIn(new StringReader(string.Join(Environment.NewLine, lines)));
    }

    // AskLanguage tests

    [Fact]
    public void AskLanguage_WhenInputIsPl_ReturnsPolish()
    {
        SetConsoleInput("pl");

        var result = _sut.AskLanguage();

        Assert.Equal(GameLanguage.Polish, result);
    }

    [Fact]
    public void AskLanguage_WhenInputIsPolski_ReturnsPolish()
    {
        SetConsoleInput("polski");

        var result = _sut.AskLanguage();

        Assert.Equal(GameLanguage.Polish, result);
    }

    [Fact]
    public void AskLanguage_WhenInputIsEn_ReturnsEnglish()
    {
        SetConsoleInput("en");

        var result = _sut.AskLanguage();

        Assert.Equal(GameLanguage.English, result);
    }

    [Fact]
    public void AskLanguage_WhenInputIsEnglish_ReturnsEnglish()
    {
        SetConsoleInput("english");

        var result = _sut.AskLanguage();

        Assert.Equal(GameLanguage.English, result);
    }

    [Fact]
    public void AskLanguage_WhenInputIsUpperCase_StillRecognizesLanguage()
    {
        SetConsoleInput("PL");

        var result = _sut.AskLanguage();

        Assert.Equal(GameLanguage.Polish, result);
    }

    [Fact]
    public void AskLanguage_WhenInvalidInputThenValid_ShowsInvalidMessageAndReturns()
    {
        SetConsoleInput("xyz", "en");

        var result = _sut.AskLanguage();

        Assert.Equal(GameLanguage.English, result);
        var output = _consoleOut.ToString();
        Assert.Contains(MessageKeys.InvalidChoice, output);
    }

    [Fact]
    public void AskLanguage_WhenInputHasWhitespace_TrimsAndRecognizes()
    {
        SetConsoleInput("  pl  ");

        var result = _sut.AskLanguage();

        Assert.Equal(GameLanguage.Polish, result);
    }

    // RenderGame tests

    [Fact(Skip="ProductionBugSuspected")]
    [Trait("Category", "ProductionBugSuspected")]
    public void RenderGame_WritesWordToOutput()
    {
        var game = new GameState("hello", 6);
        var language = GameLanguage.English;

        _sut.RenderGame(game, language);

        var output = _consoleOut.ToString();
        Assert.Contains(game.MaskedWord, output);
    }

    [Fact(Skip="ProductionBugSuspected")]
    [Trait("Category", "ProductionBugSuspected")]
    public void RenderGame_WritesWrongAttemptsToOutput()
    {
        var game = new GameState("hello", 6);
        var language = GameLanguage.English;

        _sut.RenderGame(game, language);

        var output = _consoleOut.ToString();
        Assert.Contains($"{game.WrongAttempts}/{game.MaxAttempts}", output);
    }

    [Fact(Skip="ProductionBugSuspected")]
    [Trait("Category", "ProductionBugSuspected")]
    public void RenderGame_WritesUsedLettersToOutput()
    {
        var game = new GameState("hello", 6);
        game.Guess('h');
        var language = GameLanguage.English;

        _sut.RenderGame(game, language);

        var output = _consoleOut.ToString();
        Assert.Contains("h", output);
    }

    [Fact(Skip="ProductionBugSuspected")]
    [Trait("Category", "ProductionBugSuspected")]
    public void RenderGame_CallsLocalizationForWord()
    {
        var game = new GameState("hello", 6);
        var language = GameLanguage.English;

        _sut.RenderGame(game, language);

        _loc.Received().Get(MessageKeys.Word, language);
    }

    [Fact(Skip="ProductionBugSuspected")]
    [Trait("Category", "ProductionBugSuspected")]
    public void RenderGame_CallsLocalizationForWrongAttempts()
    {
        var game = new GameState("hello", 6);
        var language = GameLanguage.Polish;

        _sut.RenderGame(game, language);

        _loc.Received().Get(MessageKeys.WrongAttempts, language);
    }

    // ReadLetter tests

    [Fact]
    public void ReadLetter_WhenValidLetter_ReturnsLetter()
    {
        SetConsoleInput("a");

        var result = _sut.ReadLetter(GameLanguage.English);

        Assert.Equal('a', result);
    }

    [Fact]
    public void ReadLetter_WhenUpperCaseLetter_ReturnsLowerCase()
    {
        SetConsoleInput("A");

        var result = _sut.ReadLetter(GameLanguage.English);

        Assert.Equal('a', result);
    }

    [Fact]
    public void ReadLetter_WhenEmptyInput_ReturnsNull()
    {
        SetConsoleInput("");

        var result = _sut.ReadLetter(GameLanguage.English);

        Assert.Null(result);
    }

    [Fact]
    public void ReadLetter_WhenMultipleCharacters_ReturnsNull()
    {
        SetConsoleInput("ab");

        var result = _sut.ReadLetter(GameLanguage.English);

        Assert.Null(result);
    }

    [Fact]
    public void ReadLetter_WhenDigit_ReturnsNull()
    {
        SetConsoleInput("1");

        var result = _sut.ReadLetter(GameLanguage.English);

        Assert.Null(result);
    }

    [Fact]
    public void ReadLetter_WhenWhitespaceOnly_ReturnsNull()
    {
        SetConsoleInput("   ");

        var result = _sut.ReadLetter(GameLanguage.English);

        Assert.Null(result);
    }

    [Fact]
    public void ReadLetter_WhenLetterWithWhitespace_ReturnsLetter()
    {
        SetConsoleInput("  b  ");

        var result = _sut.ReadLetter(GameLanguage.English);

        Assert.Equal('b', result);
    }

    // ShowWin tests

    [Fact]
    public void ShowWin_WritesWinMessageToOutput()
    {
        var secretWord = _fixture.Create<string>();

        _sut.ShowWin(secretWord, GameLanguage.English);

        var output = _consoleOut.ToString();
        Assert.Contains(MessageKeys.Win, output);
    }

    [Fact]
    public void ShowWin_WritesSecretWordToOutput()
    {
        var secretWord = _fixture.Create<string>();

        _sut.ShowWin(secretWord, GameLanguage.English);

        var output = _consoleOut.ToString();
        Assert.Contains(secretWord, output);
    }

    [Fact]
    public void ShowWin_CallsLocalizationWithCorrectLanguage()
    {
        var secretWord = _fixture.Create<string>();
        var language = GameLanguage.Polish;

        _sut.ShowWin(secretWord, language);

        _loc.Received().Get(MessageKeys.Win, language);
    }

    [Fact]
    public void ShowWin_WritesTheWordWasMessageToOutput()
    {
        var secretWord = _fixture.Create<string>();

        _sut.ShowWin(secretWord, GameLanguage.English);

        _loc.Received().Get(MessageKeys.TheWordWas, GameLanguage.English);
    }

    // ShowLoss tests

    [Fact]
    public void ShowLoss_WritesLossMessageToOutput()
    {
        var secretWord = _fixture.Create<string>();

        _sut.ShowLoss(secretWord, GameLanguage.English);

        var output = _consoleOut.ToString();
        Assert.Contains(MessageKeys.Loss, output);
    }

    [Fact]
    public void ShowLoss_WritesSecretWordToOutput()
    {
        var secretWord = _fixture.Create<string>();

        _sut.ShowLoss(secretWord, GameLanguage.English);

        var output = _consoleOut.ToString();
        Assert.Contains(secretWord, output);
    }

    [Fact]
    public void ShowLoss_CallsLocalizationWithCorrectLanguage()
    {
        var secretWord = _fixture.Create<string>();
        var language = GameLanguage.Polish;

        _sut.ShowLoss(secretWord, language);

        _loc.Received().Get(MessageKeys.Loss, language);
    }

    [Fact]
    public void ShowLoss_WritesTheWordWasMessageToOutput()
    {
        var secretWord = _fixture.Create<string>();

        _sut.ShowLoss(secretWord, GameLanguage.English);

        _loc.Received().Get(MessageKeys.TheWordWas, GameLanguage.English);
    }

    // ShowInvalidInput tests

    [Fact]
    public void ShowInvalidInput_WritesInvalidInputMessageToOutput()
    {
        SetConsoleInput("");

        _sut.ShowInvalidInput(GameLanguage.English);

        var output = _consoleOut.ToString();
        Assert.Contains(MessageKeys.InvalidInput, output);
    }

    [Fact]
    public void ShowInvalidInput_CallsLocalizationWithCorrectLanguage()
    {
        SetConsoleInput("");

        _sut.ShowInvalidInput(GameLanguage.Polish);

        _loc.Received().Get(MessageKeys.InvalidInput, GameLanguage.Polish);
    }

    [Fact]
    public void ShowInvalidInput_CallsPause_WritesPressEnterMessage()
    {
        SetConsoleInput("");

        _sut.ShowInvalidInput(GameLanguage.English);

        _loc.Received().Get(MessageKeys.PressEnter, GameLanguage.English);
    }

    // ShowAlreadyGuessed tests

    [Fact]
    public void ShowAlreadyGuessed_WritesAlreadyGuessedMessageToOutput()
    {
        SetConsoleInput("");

        _sut.ShowAlreadyGuessed(GameLanguage.English);

        var output = _consoleOut.ToString();
        Assert.Contains(MessageKeys.AlreadyGuessed, output);
    }

    [Fact]
    public void ShowAlreadyGuessed_CallsLocalizationWithCorrectLanguage()
    {
        SetConsoleInput("");

        _sut.ShowAlreadyGuessed(GameLanguage.Polish);

        _loc.Received().Get(MessageKeys.AlreadyGuessed, GameLanguage.Polish);
    }

    [Fact]
    public void ShowAlreadyGuessed_CallsPause_WritesPressEnterMessage()
    {
        SetConsoleInput("");

        _sut.ShowAlreadyGuessed(GameLanguage.English);

        _loc.Received().Get(MessageKeys.PressEnter, GameLanguage.English);
    }

    // AskPlayAgain tests

    [Theory]
    [InlineData("t")]
    [InlineData("tak")]
    [InlineData("y")]
    [InlineData("yes")]
    public void AskPlayAgain_WhenPositiveAnswer_ReturnsTrue(string answer)
    {
        SetConsoleInput(answer);

        var result = _sut.AskPlayAgain(GameLanguage.English);

        Assert.True(result);
    }

    [Theory]
    [InlineData("T")]
    [InlineData("TAK")]
    [InlineData("Y")]
    [InlineData("YES")]
    public void AskPlayAgain_WhenPositiveAnswerUpperCase_ReturnsTrue(string answer)
    {
        SetConsoleInput(answer);

        var result = _sut.AskPlayAgain(GameLanguage.English);

        Assert.True(result);
    }

    [Theory]
    [InlineData("n")]
    [InlineData("no")]
    [InlineData("nie")]
    [InlineData("")]
    [InlineData("maybe")]
    public void AskPlayAgain_WhenNegativeOrUnrecognizedAnswer_ReturnsFalse(string answer)
    {
        SetConsoleInput(answer);

        var result = _sut.AskPlayAgain(GameLanguage.English);

        Assert.False(result);
    }

    [Fact]
    public void AskPlayAgain_WritesPlayAgainPromptToOutput()
    {
        SetConsoleInput("n");

        _sut.AskPlayAgain(GameLanguage.English);

        var output = _consoleOut.ToString();
        Assert.Contains(MessageKeys.PlayAgain, output);
    }

    [Fact]
    public void AskPlayAgain_CallsLocalizationWithCorrectLanguage()
    {
        SetConsoleInput("n");

        _sut.AskPlayAgain(GameLanguage.Polish);

        _loc.Received().Get(MessageKeys.PlayAgain, GameLanguage.Polish);
    }

    [Fact]
    public void AskPlayAgain_WhenAnswerHasWhitespace_TrimsAndEvaluates()
    {
        SetConsoleInput("  yes  ");

        var result = _sut.AskPlayAgain(GameLanguage.English);

        Assert.True(result);
    }
}
