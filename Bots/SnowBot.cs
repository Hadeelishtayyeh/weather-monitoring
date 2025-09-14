public class SnowBot : IWeatherBot
{
    private readonly BotConfig _config;

    public SnowBot(BotConfig config)
    {
        _config = config;
    }

    public void CheckAndActivate(WeatherData data)
    {    Console.WriteLine($"[Debug] SnowBot Enabled: {_config.Enabled}, Threshold: {_config.TemperatureThreshold}, CurrentTemp: {data.Temperature}");

        if (_config.Enabled && data.Temperature < _config.TemperatureThreshold)
        {
            Console.WriteLine("SnowBot activated!");
            Console.WriteLine($"SnowBot: \"{_config.Message}\"");
        }
    }
}
