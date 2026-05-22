using Hangman.Domain;

namespace Hangman.Application;

public sealed class StartGameUseCase(IWordProvider wordProvider)
{
    public GameState Execute(GameLanguage language, int maxAttempts = 6)
    {
        var word = wordProvider.GetRandomWord(language);
        return new GameState(word, maxAttempts);
    }
}
