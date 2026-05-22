namespace Hangman.Application;

public interface IWordProvider
{
    string GetRandomWord(GameLanguage language);
}
