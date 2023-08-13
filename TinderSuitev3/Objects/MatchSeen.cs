using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class MatchSeen
    {
        [JsonProperty("match_seen")] public bool Seen { get; set; }
    }
}