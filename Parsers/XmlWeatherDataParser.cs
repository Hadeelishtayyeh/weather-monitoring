using System.IO;
using System.Xml.Serialization;

public class XmlWeatherDataParser : IWeatherDataParser
{
    public bool CanParse(string input)
    {
        return input.TrimStart().StartsWith("<");
    }

    public WeatherData Parse(string input)
    {
        var serializer = new XmlSerializer(typeof(WeatherData));
        using (TextReader reader = new StringReader(input))
        {
            return (WeatherData)serializer.Deserialize(reader)!;
        }
    }
}
