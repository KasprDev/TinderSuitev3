﻿using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class TinderInformation
    {
        [JsonProperty("globals")] public Globals Globals { get; set; }

        [JsonProperty("versions")] public Versions Versions { get; set; }

        [JsonProperty("token")] public string Token { get; set; }

        [JsonProperty("user")] public User User { get; set; }
    }
}