using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class RateCard
    {
        [JsonProperty("carousel")] public IList<Carousel> Carousel { get; set; }
    }
}