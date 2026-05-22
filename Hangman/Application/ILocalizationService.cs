namespace Hangman.Application;

public interface ILocalizationService
{
    string Get(string key, GameLanguage language);
}
