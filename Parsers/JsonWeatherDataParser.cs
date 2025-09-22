using System.Text.Json;

public class JsonWeatherDataParser : IWeatherDataParser
{
    public bool CanParse(string input)
    {
        return input.TrimStart().StartsWith("{");
    }

    public WeatherData Parse(string input)
    {
        try
        {
            return JsonSerializer.Deserialize<WeatherData>(input)
                   ?? throw new JsonException("Deserialized object is null.");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON parsing failed: {ex.Message}");
            throw new FormatException("Invalid JSON format for WeatherData.", ex);
        }
    }
}
