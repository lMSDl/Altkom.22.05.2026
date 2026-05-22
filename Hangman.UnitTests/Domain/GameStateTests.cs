using AutoFixture;
using Hangman.Domain;

namespace Hangman.UnitTests.Domain;

public class GameStateTests
{
    private readonly Fixture _fixture = new();

    // Constructor tests

    [Fact]
    public void Constructor_WithValidWord_SetsSecretWordToLowerInvariantTrimmed()
    {
        var state = new GameState("  Hello  ");

        Assert.Equal("hello", state.SecretWord);
    }

    [Fact]
    public void Constructor_WithValidWord_SetsMaxAttempts()
    {
        var state = new GameState("hello", 10);

        Assert.Equal(10, state.MaxAttempts);
    }

    [Fact]
    public void Constructor_DefaultMaxAttempts_IsSix()
    {
        var state = new GameState("hello");

        Assert.Equal(6, state.MaxAttempts);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_WithEmptyOrWhiteSpaceWord_ThrowsArgumentException(string? secretWord)
    {
        Assert.Throws<ArgumentException>(() => new GameState(secretWord!));
    }

    [Fact]
    public void Constructor_WithUpperCaseWord_StoresAsLowerCase()
    {
        var state = new GameState("WORLD");

        Assert.Equal("world", state.SecretWord);
    }

    [Fact]
    public void Constructor_WithMixedCaseWord_StoresAsLowerCase()
    {
        var state = new GameState("HeLLo");

        Assert.Equal("hello", state.SecretWord);
    }

    // GuessedLetters tests

    [Fact]
    public void GuessedLetters_InitialState_IsEmpty()
    {
        var state = new GameState(_fixture.Create<string>().Replace(" ", "a") + "a");

        Assert.Empty(state.GuessedLetters);
    }

    [Fact]
    public void GuessedLetters_AfterCorrectGuess_ContainsGuessedLetter()
    {
        var state = new GameState("hello");
        state.Guess('h');

        Assert.Contains('h', state.GuessedLetters);
    }

    [Fact]
    public void GuessedLetters_AfterMultipleGuesses_ContainsAllGuessedLetters()
    {
        var state = new GameState("hello");
        state.Guess('h');
        state.Guess('e');
        state.Guess('x'); // wrong guess

        Assert.Contains('h', state.GuessedLetters);
        Assert.Contains('e', state.GuessedLetters);
        Assert.Contains('x', state.GuessedLetters);
    }

    // IsWon tests

    [Fact]
    public void IsWon_InitialState_IsFalse()
    {
        var state = new GameState("hi");

        Assert.False(state.IsWon);
    }

    [Fact]
    public void IsWon_AllLettersGuessed_IsTrue()
    {
        var state = new GameState("hi");
        state.Guess('h');
        state.Guess('i');

        Assert.True(state.IsWon);
    }

    [Fact]
    public void IsWon_PartialLettersGuessed_IsFalse()
    {
        var state = new GameState("hi");
        state.Guess('h');

        Assert.False(state.IsWon);
    }

    // IsLost tests

    [Fact]
    public void IsLost_InitialState_IsFalse()
    {
        var state = new GameState("hello", 3);

        Assert.False(state.IsLost);
    }

    [Fact]
    public void IsLost_WrongAttemptsEqualMaxAttempts_IsTrue()
    {
        var state = new GameState("hello", 3);
        state.Guess('x');
        state.Guess('y');
        state.Guess('z');

        Assert.True(state.IsLost);
    }

    [Fact]
    public void IsLost_WrongAttemptsLessThanMaxAttempts_IsFalse()
    {
        var state = new GameState("hello", 3);
        state.Guess('x');
        state.Guess('y');

        Assert.False(state.IsLost);
    }

    [Fact]
    public void IsLost_WrongAttemptsExceedMaxAttempts_IsTrue()
    {
        // maxAttempts=1, but after game is lost no more guesses are processed (Invalid returned)
        // so we just verify at exactly maxAttempts
        var state = new GameState("hello", 2);
        state.Guess('x');
        state.Guess('y');

        Assert.True(state.IsLost);
    }

    // MaskedWord tests

    [Fact]
    public void MaskedWord_InitialState_AllUnderscores()
    {
        var state = new GameState("hi");

        Assert.Equal("_ _", state.MaskedWord);
    }

    [Fact]
    public void MaskedWord_OneLetterGuessed_RevealsGuessedLetter()
    {
        var state = new GameState("hi");
        state.Guess('h');

        Assert.Equal("h _", state.MaskedWord);
    }

    [Fact]
    public void MaskedWord_AllLettersGuessed_RevealsFullWord()
    {
        var state = new GameState("hi");
        state.Guess('h');
        state.Guess('i');

        Assert.Equal("h i", state.MaskedWord);
    }

    [Fact]
    public void MaskedWord_RepeatedLetterInWord_RevealsAllOccurrences()
    {
        var state = new GameState("aab");
        state.Guess('a');

        Assert.Equal("a a _", state.MaskedWord);
    }

    [Fact]
    public void MaskedWord_WrongLetterGuessed_DoesNotRevealAnyLetter()
    {
        var state = new GameState("hi");
        state.Guess('z');

        Assert.Equal("_ _", state.MaskedWord);
    }

    // Guess method tests

    [Fact]
    public void Guess_WhenGameAlreadyWon_ReturnsInvalid()
    {
        var state = new GameState("hi");
        state.Guess('h');
        state.Guess('i');

        var result = state.Guess('h');

        Assert.Equal(GuessResult.Invalid, result);
    }

    [Fact]
    public void Guess_WhenGameAlreadyLost_ReturnsInvalid()
    {
        var state = new GameState("hello", 2);
        state.Guess('x');
        state.Guess('y');

        var result = state.Guess('e');

        Assert.Equal(GuessResult.Invalid, result);
    }

    [Theory]
    [InlineData('1')]
    [InlineData('!')]
    [InlineData(' ')]
    [InlineData('9')]
    public void Guess_NonLetterCharacter_ReturnsInvalid(char nonLetter)
    {
        var state = new GameState("hello");

        var result = state.Guess(nonLetter);

        Assert.Equal(GuessResult.Invalid, result);
    }

    [Fact]
    public void Guess_LetterInWord_ReturnsCorrect()
    {
        var state = new GameState("hello");

        var result = state.Guess('h');

        Assert.Equal(GuessResult.Correct, result);
    }

    [Fact]
    public void Guess_LetterNotInWord_ReturnsIncorrect()
    {
        var state = new GameState("hello");

        var result = state.Guess('z');

        Assert.Equal(GuessResult.Incorrect, result);
    }

    [Fact]
    public void Guess_LetterNotInWord_IncrementsWrongAttempts()
    {
        var state = new GameState("hello");

        state.Guess('z');

        Assert.Equal(1, state.WrongAttempts);
    }

    [Fact]
    public void Guess_LetterInWord_DoesNotIncrementWrongAttempts()
    {
        var state = new GameState("hello");

        state.Guess('h');

        Assert.Equal(0, state.WrongAttempts);
    }

    [Fact]
    public void Guess_AlreadyGuessedLetter_ReturnsAlreadyGuessed()
    {
        var state = new GameState("hello");
        state.Guess('h');

        var result = state.Guess('h');

        Assert.Equal(GuessResult.AlreadyGuessed, result);
    }

    [Fact]
    public void Guess_AlreadyGuessedWrongLetter_ReturnsAlreadyGuessed()
    {
        var state = new GameState("hello");
        state.Guess('z');

        var result = state.Guess('z');

        Assert.Equal(GuessResult.AlreadyGuessed, result);
    }

    [Fact]
    public void Guess_AlreadyGuessedLetter_DoesNotIncrementWrongAttempts()
    {
        var state = new GameState("hello");
        state.Guess('z');

        state.Guess('z');

        Assert.Equal(1, state.WrongAttempts);
    }

    [Fact]
    public void Guess_UpperCaseLetter_TreatedAsCaseInsensitive()
    {
        var state = new GameState("hello");

        var result = state.Guess('H');

        Assert.Equal(GuessResult.Correct, result);
    }

    [Fact]
    public void Guess_UpperCaseLetter_StoredAsLowerCase()
    {
        var state = new GameState("hello");
        state.Guess('H');

        Assert.Contains('h', state.GuessedLetters);
        Assert.DoesNotContain('H', state.GuessedLetters);
    }

    [Fact]
    public void Guess_UpperCaseAlreadyGuessedAsLowerCase_ReturnsAlreadyGuessed()
    {
        var state = new GameState("hello");
        state.Guess('h');

        var result = state.Guess('H');

        Assert.Equal(GuessResult.AlreadyGuessed, result);
    }

    [Fact]
    public void Guess_CorrectLetter_AddedToGuessedLetters()
    {
        var state = new GameState("hello");

        state.Guess('e');

        Assert.Contains('e', state.GuessedLetters);
    }

    [Fact]
    public void Guess_IncorrectLetter_AddedToGuessedLetters()
    {
        var state = new GameState("hello");

        state.Guess('z');

        Assert.Contains('z', state.GuessedLetters);
    }

    [Fact]
    public void Guess_NonLetterCharacter_NotAddedToGuessedLetters()
    {
        var state = new GameState("hello");

        state.Guess('1');

        Assert.Empty(state.GuessedLetters);
    }

    [Fact]
    public void Guess_NonLetterCharacter_DoesNotIncrementWrongAttempts()
    {
        var state = new GameState("hello");

        state.Guess('1');

        Assert.Equal(0, state.WrongAttempts);
    }

    [Fact]
    public void Guess_AllCorrectLetters_WinsGame()
    {
        var state = new GameState("hi");
        state.Guess('h');
        state.Guess('i');

        Assert.True(state.IsWon);
    }

    [Fact]
    public void Guess_MaxWrongAttempts_LosesGame()
    {
        var state = new GameState("hello", 3);
        state.Guess('x');
        state.Guess('y');
        state.Guess('z');

        Assert.True(state.IsLost);
    }
}
