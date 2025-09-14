using System.Text.Json;
using System.IO;
using System.Collections.Generic;
public static class ConfigLoader
{
    public static Dictionary<string, BotConfig> LoadConfig(string path)
    {
        string json = File.ReadAllText(path);
        
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<Dictionary<string, BotConfig>>(json, options)!;
    }
}
