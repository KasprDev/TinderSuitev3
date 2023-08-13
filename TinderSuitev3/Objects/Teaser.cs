using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class Teaser
    {
        [JsonProperty("string")] public string String { get; set; }

        [JsonProperty("type")] public string Type { get; set; }
    }
}