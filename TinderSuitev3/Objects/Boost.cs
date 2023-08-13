using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class Boost
    {
        [JsonProperty("regular")] public Regular Regular { get; set; }
    }
}