﻿using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class Interest
    {
        [JsonProperty("category_list")] public IList<CategoryList> CategoryList { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("category")] public string Category { get; set; }

        [JsonProperty("created_time")] public DateTime CreatedTime { get; set; }
    }
}