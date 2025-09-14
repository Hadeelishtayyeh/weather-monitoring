using System;
using System.Collections.Generic;


        var config = ConfigLoader.LoadConfig("config.json");

        var bots = new List<IWeatherBot>
        {
            new RainBot(config["RainBot"]),
            new SunBot(config["SunBot"]),
            new SnowBot(config["SnowBot"])
        };

        var botManager = new BotManager(bots);

        var parsers = new List<IWeatherDataParser>
        {
            new JsonWeatherDataParser(),
            new XmlWeatherDataParser()
        };

        while (true)
        {
            Console.WriteLine("\nEnter weather data ( type or 'exit' to quit):");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "exit")
                break;

            WeatherData data = null;

            foreach (var parser in parsers)
            {
                if (parser.CanParse(input))
                {
                    try
                    {
                        data = parser.Parse(input);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error parsing data: {ex.Message}");
                        data = null;
                        break;
                    }
                }
            }

            if (data != null)
            {
                botManager.HandleWeatherUpdate(data);
            }
            else
            {
                Console.WriteLine("Invalid input format. Please enter valid JSON or XML.");
            }
        }
    