using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class Travel
    {
        [JsonProperty("is_traveling")] public bool IsTraveling { get; set; }
    }
}