using System;
using System.Collections.Generic;

var config = ConfigLoader.LoadConfig("appsettings.json");

var bots = WeatherBotFactory.CreateBots(config);

var botManager = new BotManager(bots);

var jsonParser = new JsonWeatherDataParser();
var xmlParser = new XmlWeatherDataParser();

var parsingStrategy = new WeatherDataParsingStrategy(jsonParser);

while (true)
{
    Console.WriteLine("\nEnter weather data (or type 'exit' to quit):");
    string? input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input))
        continue;

    if (input.Trim().ToLower() == "exit")
        break;

    if (jsonParser.CanParse(input))
    {
        parsingStrategy.SetParser(jsonParser);
    }
    else if (xmlParser.CanParse(input))
    {
        parsingStrategy.SetParser(xmlParser);
    }
    else
    {
        Console.WriteLine("Invalid input format. Please enter valid JSON or XML.");
        continue;
    }

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
