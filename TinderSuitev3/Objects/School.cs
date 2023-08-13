using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class School
    {
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("id")] public string Id { get; set; }
    }
}