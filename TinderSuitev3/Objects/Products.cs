using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class Products
    {
        [JsonProperty("superlike")] public Superlike Superlike { get; set; }

        [JsonProperty("boost")] public Boost Boost { get; set; }
    }
}