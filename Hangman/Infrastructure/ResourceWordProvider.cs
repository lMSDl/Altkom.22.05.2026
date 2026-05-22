using System.Globalization;
using System.Resources;
using Hangman.Application;

namespace Hangman.Infrastructure;

public sealed class ResourceWordProvider : IWordProvider
{
    private static readonly ResourceManager Manager =
        new("Hangman.Resources.Words", typeof(ResourceWordProvider).Assembly);

    public string GetRandomWord(GameLanguage language)
    {
        var culture = language == GameLanguage.English
            ? new CultureInfo("en")
            : new CultureInfo("pl");

        var csv = Manager.GetString("Words", culture) ?? string.Empty;
        var words = csv.Split(';', StringSplitOptions.RemoveEmptyEntries);

        if (words.Length == 0)
        {
            throw new InvalidOperationException($"No words found for language: {language}");
        }

        return words[Random.Shared.Next(words.Length)];
    }
}
