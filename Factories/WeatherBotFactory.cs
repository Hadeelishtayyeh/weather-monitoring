using System.Collections.Generic;

public static class WeatherBotFactory
{
    public static List<IWeatherBot> CreateBots(Dictionary<string, BotConfig> config)
    {
        var bots = new List<IWeatherBot>();

        foreach (var pair in config)
        {
            var botName = pair.Key;
            var botConfig = pair.Value;

            switch (botName)
            {
                case "RainBot":
                    bots.Add(new RainBot(botConfig));
                    break;
                case "SunBot":
                    bots.Add(new SunBot(botConfig));
                    break;
                case "SnowBot":
                    bots.Add(new SnowBot(botConfig));
                    break;
                default:
                    Console.WriteLine($"Warning: Unknown bot '{botName}' in configuration.");
                    break;
            }
        }

        return bots;
    }
}
