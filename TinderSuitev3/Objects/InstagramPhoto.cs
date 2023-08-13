using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class InstagramPhoto
    {
        [JsonProperty("image")] public string Image { get; set; }

        [JsonProperty("thumbnail")] public string Thumbnail { get; set; }

        [JsonProperty("ts")] public string Ts { get; set; }

        [JsonProperty("link")] public string Link { get; set; }
    }
}