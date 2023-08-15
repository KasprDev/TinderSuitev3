using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public partial class ProcessedFile
    {
        [JsonProperty("width")] public int Width { get; set; }

        [JsonProperty("url")] public string Url { get; set; }

        [JsonProperty("height")] public int Height { get; set; }
    }
}