﻿using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class CommonInterest
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }
    }
}