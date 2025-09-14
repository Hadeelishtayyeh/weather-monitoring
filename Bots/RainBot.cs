public class RainBot  : IWeatherBot
{
    private readonly BotConfig _config;

    public RainBot (BotConfig config)
    {
        _config = config;
    }

    public void CheckAndActivate(WeatherData data)
    {
        if (_config.Enabled && data.Humidity > _config.HumidityThreshold)
        {
            Console.WriteLine("RainBot activated!");
            Console.WriteLine($"RainBot: \"{_config.Message}\"");
        }
    }
}
