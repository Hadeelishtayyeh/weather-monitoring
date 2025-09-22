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
        try
        {
            using TextReader reader = new StringReader(input);
            return (WeatherData)serializer.Deserialize(reader)
                   ?? throw new InvalidOperationException("Deserialized XML is null.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"XML parsing failed: {ex.Message}");
            throw new FormatException("Invalid XML format for WeatherData.", ex);
        }
    }
}
