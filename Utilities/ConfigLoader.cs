using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

public static class ConfigLoader
{
    public static Dictionary<string, BotConfig> LoadConfig(string path)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(path, optional: false, reloadOnChange: false)
            .Build();

        var botConfigs = new Dictionary<string, BotConfig>();
        configuration.Bind(botConfigs); 

        return botConfigs;
    }
}
