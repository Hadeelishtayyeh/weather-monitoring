using System.Text.Json;

public class JsonWeatherDataParser : IWeatherDataParser
{
    public bool CanParse(string input)
    {
        return input.TrimStart().StartsWith("{");
    }

    public WeatherData Parse(string input)
    {
        return JsonSerializer.Deserialize<WeatherData>(input)!;
    }
}
