using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class Title
    {
        [JsonProperty("name")] public string Name { get; set; }
    }
}