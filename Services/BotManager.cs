using System.Collections.Generic;

public class BotManager
{
    private readonly List<IWeatherBot> _bots;

    public BotManager(List<IWeatherBot> bots)
    {
        _bots = bots;
    }

    public void HandleWeatherUpdate(WeatherData data)
    {
        foreach (var bot in _bots)
        {
            bot.CheckAndActivate(data);
        }
    }
}
