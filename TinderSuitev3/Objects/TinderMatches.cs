using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class TinderMatches
    {
        [JsonProperty("data")] public MatchData Data { get; set; }
    }
}