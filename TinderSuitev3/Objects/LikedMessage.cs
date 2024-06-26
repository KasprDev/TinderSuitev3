﻿using Newtonsoft.Json;

namespace TinderSuitev3.Objects
{
    public class LikedMessage
    {
        [JsonProperty("message_id")] public string MessageId { get; set; }

        [JsonProperty("updated_at")] public string UpdatedAt { get; set; }

        [JsonProperty("liker_id")] public string LikerId { get; set; }

        [JsonProperty("match_id")] public string MatchId { get; set; }

        [JsonProperty("is_liked")] public bool IsLiked { get; set; }
    }
}