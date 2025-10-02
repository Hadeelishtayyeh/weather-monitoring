public class SnowBot : WeatherBot
{
    public SnowBot(BotConfig config) : base(config) {}

    public override void CheckAndActivate(WeatherData data)
    {
        Console.WriteLine($"[Debug] SnowBot Enabled: {_config.Enabled}, Threshold: {_config.TemperatureThreshold}, CurrentTemp: {data.Temperature}");

        if (_config.Enabled && data.Temperature < _config.TemperatureThreshold)
        {
            ActivateBot("SnowBot");
        }
    }
}
