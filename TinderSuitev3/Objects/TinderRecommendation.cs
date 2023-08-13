using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class TinderRecommendation
    {
        [JsonProperty("status")] public int Status { get; set; }

        [JsonProperty("data")] public Result Data { get; set; }
        [JsonProperty("message")] public string Message { get; set; }
    }
}