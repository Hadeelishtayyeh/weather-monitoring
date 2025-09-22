using System;
using System.Collections.Generic;

var config = ConfigLoader.LoadConfig("appsettings.json");

var bots = WeatherBotFactory.CreateBots(config);

var botManager = new BotManager(bots);

var parsers = new List<IWeatherDataParser>
{
    new JsonWeatherDataParser(),
    new XmlWeatherDataParser()
};

var parsingStrategy = new WeatherDataParsingStrategy(parsers);

while (true)
{
    Console.WriteLine("\nEnter weather data (or type 'exit' to quit):");
    string input = Console.ReadLine();

    if (input.Trim().ToLower() == "exit")
        break;

    var data = parsingStrategy.Parse(input);

    if (data != null)
    {
        botManager.HandleWeatherUpdate(data);
    }
    else
    {
        Console.WriteLine("Invalid input format. Please enter valid JSON or XML.");
    }
}
