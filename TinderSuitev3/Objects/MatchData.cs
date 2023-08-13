using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class MatchData
    {
        [JsonProperty("data")] public MatchesData Data { get; set; }
    }

    public class MatchesData
    {
        [JsonProperty("matches")] public IList<Match>? Matches { get; set; }
    }
}