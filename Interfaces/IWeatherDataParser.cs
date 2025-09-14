public interface IWeatherDataParser
{
    bool CanParse(string input);
    WeatherData Parse(string input);
}