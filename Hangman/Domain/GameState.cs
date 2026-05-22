namespace Hangman.Domain;

public sealed class GameState
{
    private readonly HashSet<char> _guessedLetters = [];

    public GameState(string secretWord, int maxAttempts = 6)
    {
        if (string.IsNullOrWhiteSpace(secretWord))
        {
            throw new ArgumentException("Secret word cannot be empty.", nameof(secretWord));
        }

        SecretWord = secretWord.Trim().ToLowerInvariant();
        MaxAttempts = maxAttempts;
    }

    public string SecretWord { get; }

    public int MaxAttempts { get; }

    public int WrongAttempts { get; private set; }

    public IReadOnlyCollection<char> GuessedLetters => _guessedLetters;

    public bool IsWon => SecretWord.All(_guessedLetters.Contains);

    public bool IsLost => WrongAttempts >= MaxAttempts;

    public string MaskedWord => string.Join(' ', SecretWord.Select(c => _guessedLetters.Contains(c) ? c : '_'));

    public GuessResult Guess(char letter)
    {
        if (IsWon || IsLost)
        {
            return GuessResult.Invalid;
        }

        letter = char.ToLowerInvariant(letter);

        if (!char.IsLetter(letter))
        {
            return GuessResult.Invalid;
        }

        if (!_guessedLetters.Add(letter))
        {
            return GuessResult.AlreadyGuessed;
        }

        if (SecretWord.Contains(letter))
        {
            return GuessResult.Correct;
        }

        WrongAttempts++;
        return GuessResult.Incorrect;
    }
}
