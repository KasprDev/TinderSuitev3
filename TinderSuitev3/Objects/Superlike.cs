using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class Superlike
    {
        [JsonProperty("regular")] public Regular Regular { get; set; }
    }
}