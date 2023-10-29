namespace Questionnaire.Extensions;

public static class DictionaryExtensions
{
    public static int ValueAsInt(this IDictionary<string, object> dictionary, string key, int defaultValue = 0) =>
        dictionary.ContainsKey(key) && dictionary[key] is int intValue
            ? intValue
            : defaultValue;
}