using System.Globalization;
using System.Resources;
using Hangman.Application;

namespace Hangman.Infrastructure;

public sealed class ResourceLocalizationService : ILocalizationService
{
    private static readonly ResourceManager Manager =
        new("Hangman.Resources.Messages", typeof(ResourceLocalizationService).Assembly);

    public string Get(string key, GameLanguage language)
    {
        var culture = language == GameLanguage.English
            ? new CultureInfo("en")
            : new CultureInfo("pl");

        return Manager.GetString(key, culture) ?? key;
    }
}
