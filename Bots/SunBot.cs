public class SunBot : IWeatherBot
{
    private readonly BotConfig _config;

    public SunBot(BotConfig config)
    {
        _config = config;
    }

    public void CheckAndActivate(WeatherData data)
    {
        if (_config.Enabled && data.Temperature > _config.TemperatureThreshold)
        {
            Console.WriteLine("SunBot activated!");
            Console.WriteLine($"SunBot: \"{_config.Message}\"");
        }
    }
}
