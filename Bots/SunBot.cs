public class SunBot : WeatherBot
{
    public SunBot(BotConfig config) : base(config) {}

    public override void CheckAndActivate(WeatherData data)
    {
        if (_config.Enabled && data.Temperature > _config.TemperatureThreshold)
        {
            ActivateBot("SunBot");
        }
    }
}
