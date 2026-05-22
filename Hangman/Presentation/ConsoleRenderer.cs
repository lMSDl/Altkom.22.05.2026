using Hangman.Application;
using Hangman.Domain;

namespace Hangman.Presentation;

public sealed class ConsoleRenderer(ILocalizationService loc)
{
    private static readonly string[] HangmanStates =
    [
        """
         +---+
         |   |
             |
             |
             |
             |
        =========
        """,
        """
         +---+
         |   |
         O   |
             |
             |
             |
        =========
        """,
        """
         +---+
         |   |
         O   |
         |   |
             |
             |
        =========
        """,
        """
         +---+
         |   |
         O   |
        /|   |
             |
             |
        =========
        """,
        """
         +---+
         |   |
         O   |
        /|\  |
             |
             |
        =========
        """,
        """
         +---+
         |   |
         O   |
        /|\  |
        /    |
             |
        =========
        """,
        """
         +---+
         |   |
         O   |
        /|\  |
        / \  |
             |
        =========
        """
    ];

    public GameLanguage AskLanguage()
    {
        while (true)
        {
            Console.Write($"{loc.Get(MessageKeys.ChooseLanguage, GameLanguage.Polish)}: ");
            var input = Console.ReadLine()?.Trim().ToLowerInvariant();

            if (input is "pl" or "polski")
            {
                return GameLanguage.Polish;
            }

            if (input is "en" or "english")
            {
                return GameLanguage.English;
            }

            Console.WriteLine(loc.Get(MessageKeys.InvalidChoice, GameLanguage.Polish));
        }
    }

    public void RenderGame(GameState game, GameLanguage language)
    {
        Console.Clear();
        Console.WriteLine(HangmanStates[Math.Clamp(game.WrongAttempts, 0, game.MaxAttempts)]);
        Console.WriteLine($"{loc.Get(MessageKeys.Word, language)}: {game.MaskedWord}");
        Console.WriteLine($"{loc.Get(MessageKeys.WrongAttempts, language)}: {game.WrongAttempts}/{game.MaxAttempts}");
        Console.WriteLine($"{loc.Get(MessageKeys.UsedLetters, language)}: {string.Join(", ", game.GuessedLetters.OrderBy(c => c))}");
    }

    public char? ReadLetter(GameLanguage language)
    {
        Console.Write($"\n{loc.Get(MessageKeys.EnterLetter, language)}: ");
        var input = Console.ReadLine()?.Trim().ToLowerInvariant();

        if (string.IsNullOrWhiteSpace(input) || input.Length != 1 || !char.IsLetter(input[0]))
        {
            return null;
        }

        return input[0];
    }

    public void ShowWin(string secretWord, GameLanguage language)
    {
        Console.WriteLine($"\n{loc.Get(MessageKeys.Win, language)}");
        Console.WriteLine($"{loc.Get(MessageKeys.TheWordWas, language)}: {secretWord}");
    }

    public void ShowLoss(string secretWord, GameLanguage language)
    {
        Console.WriteLine($"\n{loc.Get(MessageKeys.Loss, language)}");
        Console.WriteLine($"{loc.Get(MessageKeys.TheWordWas, language)}: {secretWord}");
    }

    public void ShowInvalidInput(GameLanguage language)
    {
        Console.WriteLine(loc.Get(MessageKeys.InvalidInput, language));
        Pause(language);
    }

    public void ShowAlreadyGuessed(GameLanguage language)
    {
        Console.WriteLine(loc.Get(MessageKeys.AlreadyGuessed, language));
        Pause(language);
    }

    public bool AskPlayAgain(GameLanguage language)
    {
        Console.Write($"\n{loc.Get(MessageKeys.PlayAgain, language)}: ");
        var answer = Console.ReadLine()?.Trim().ToLowerInvariant();
        return answer is "t" or "tak" or "y" or "yes";
    }

    private void Pause(GameLanguage language)
    {
        Console.Write(loc.Get(MessageKeys.PressEnter, language));
        Console.ReadLine();
    }
}
