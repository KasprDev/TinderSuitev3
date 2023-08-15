using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public partial class Teaser
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("is_range")]
        public bool IsRange { get; set; }

        [JsonProperty("pre_blur")]
        public bool PreBlur { get; set; }

        [JsonProperty("teaser_url")]
        public Uri TeaserUrl { get; set; }
    }
}
