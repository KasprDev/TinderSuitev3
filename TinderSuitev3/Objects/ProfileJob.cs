using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class ProfileJob
    {
        [JsonProperty("company")] public ProfileCompany Company { get; set; }
    }
}