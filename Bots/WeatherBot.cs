public abstract class WeatherBot : IWeatherBot
{
    protected readonly BotConfig _config;

    protected WeatherBot(BotConfig config)
    {
        _config = config;
    }

    protected void ActivateBot(string botName)
    {
        Console.WriteLine($"{botName} activated!");
        Console.WriteLine(_config.Message);
    }

    public abstract void CheckAndActivate(WeatherData data);
}
