using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class UserResultPhoto
    {
        [JsonProperty("fileName")] public string FileName { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("extension")] public string Extension { get; set; }

        [JsonProperty("processedFiles")] public IList<ProcessedFile> ProcessedFiles { get; set; }

        [JsonProperty("url")] public string Url { get; set; }

        [JsonProperty("main")] public string Main { get; set; }

        [JsonProperty("shape")] public string Shape { get; set; }
    }
}