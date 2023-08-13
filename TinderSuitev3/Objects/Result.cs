using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class Result
    {
        [JsonProperty("results")] public IList<TinderRecommendedUser>? Results { get; set; }
    }

    public class TinderRecommendedUser
    {
        [JsonProperty("user")] public TinderUser User { get; set; }

        [JsonProperty("dead")] public bool Dead { get; set; }

        [JsonProperty("match_seen")] public bool MatchSeen { get; set; }

        [JsonProperty("has_shown_initial_interest")]
        public bool HasShownInitialInterest { get; set; }

        [JsonProperty("distance_mi")] public int Distance { get; set; }

        [JsonProperty("is_fast_match")] public bool IsFastMatch { get; set; }

        [JsonProperty("s_number")] public long SNumber { get; set; }
    }
}