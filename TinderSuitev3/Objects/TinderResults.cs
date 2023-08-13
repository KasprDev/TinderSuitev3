using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    class TinderResults
    {
        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("user")] public string User { get; set; }
    }
}