using System.Text;
using Hangman.Application;
using Hangman.Domain;
using Hangman.Infrastructure;
using Hangman.Presentation;

namespace Hangman;

internal static class Program
{
    private const int MaxAttempts = 6;

    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        IWordProvider wordProvider = new ResourceWordProvider();
        ILocalizationService localization = new ResourceLocalizationService();
        var renderer = new ConsoleRenderer(localization);
        var startGame = new StartGameUseCase(wordProvider);

        var language = renderer.AskLanguage();

        bool playAgain;

        do
        {
            RunSingleGame(startGame, renderer, language);
            playAgain = renderer.AskPlayAgain(language);
        }
        while (playAgain);
    }

    private static void RunSingleGame(StartGameUseCase startGame, ConsoleRenderer renderer, GameLanguage language)
    {
        var game = startGame.Execute(language, MaxAttempts);

        while (!game.IsWon && !game.IsLost)
        {
            renderer.RenderGame(game, language);

            var letter = renderer.ReadLetter(language);
            if (letter is null)
            {
                renderer.ShowInvalidInput(language);
                continue;
            }

            var guessResult = game.Guess(letter.Value);

            if (guessResult == GuessResult.AlreadyGuessed)
            {
                renderer.ShowAlreadyGuessed(language);
            }
        }

        renderer.RenderGame(game, language);

        if (game.IsWon)
        {
            renderer.ShowWin(game.SecretWord, language);
            return;
        }

        renderer.ShowLoss(game.SecretWord, language);
    }
}
