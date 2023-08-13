using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class Company
    {
        [JsonProperty("name")] public string Name { get; set; }
    }
}