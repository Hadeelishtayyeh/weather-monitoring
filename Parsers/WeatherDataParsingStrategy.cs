using System;
using System.Collections.Generic;

public class WeatherDataParsingStrategy
{
    private IWeatherDataParser _parser;

    public WeatherDataParsingStrategy(IWeatherDataParser parser)
    {
        _parser = parser;
    }

    public void SetParser(IWeatherDataParser parser)
    {
        _parser = parser;
    }

    public WeatherData? Parse(string input)
    {
        try
        {
            if (_parser.CanParse(input))
            {
                return _parser.Parse(input);
            }
        }
        catch
        {
            return null;
        }

        return null;
    }
}
