public class RainBot : WeatherBot
{
    public RainBot(BotConfig config) : base(config) {}

    public override void CheckAndActivate(WeatherData data)
    {
        if (_config.Enabled && data.Humidity > _config.HumidityThreshold)
        {
            ActivateBot("RainBot");
        }
    }
}
