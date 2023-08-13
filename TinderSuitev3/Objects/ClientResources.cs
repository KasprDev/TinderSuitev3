using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class ClientResources
    {
        [JsonProperty("rate_card")] public RateCard RateCard { get; set; }

        [JsonProperty("plus_screen")] public IList<string> PlusScreen { get; set; }
    }
}