using System;
using System.Collections.Generic;

public class WeatherDataParsingStrategy
{
    private readonly List<IWeatherDataParser> _parsers;

    public WeatherDataParsingStrategy(IEnumerable<IWeatherDataParser> parsers)
    {
        _parsers = new List<IWeatherDataParser>(parsers);
    }

    public WeatherData? Parse(string input)
    {
        foreach (var parser in _parsers)
        {
            if (parser.CanParse(input))
            {
                try
                {
                    return parser.Parse(input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error parsing data with {parser.GetType().Name}: {ex.Message}");
                    return null;
                }
            }
        }

        return null;
    }
}
