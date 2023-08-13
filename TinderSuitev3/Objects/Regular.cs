using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class Regular
    {
        [JsonProperty("skus")] public IList<Sku> Skus { get; set; }
    }
}