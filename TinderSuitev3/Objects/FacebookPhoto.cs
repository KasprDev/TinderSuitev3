﻿using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class FacebookPhoto
    {
        [JsonProperty("small")] public string Small { get; set; }

        [JsonProperty("medium")] public string Medium { get; set; }

        [JsonProperty("large")] public string Large { get; set; }
    }
}