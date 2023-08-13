using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class Job
    {
        [JsonProperty("company")] public Company? Company { get; set; }

        [JsonProperty("title")] public Title? Title { get; set; }
    }
}