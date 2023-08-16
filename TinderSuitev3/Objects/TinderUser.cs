using Newtonsoft.Json;
using QuickType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderSuitev3.Objects
{
    public class TinderUser
    {
        [JsonProperty("distance_mi")] public int DistanceMi { get; set; }
        [JsonProperty("is_fast_match")] public bool IsFastMatch { get; set; }

        [JsonProperty("s_number")] public long SNumber { get; set; }

        [JsonProperty("selected_descriptors")] public TinderUserDescriptor[]? Descriptors { get; set; }

        [JsonProperty("common_friend_count")]
        public long CommonFriendCount { get; set; }

        [JsonProperty("spotify_top_artists")]
        public object[] SpotifyTopArtists { get; set; }

        [JsonProperty("spotify_theme_track")]
        public SpotifyThemeTrack SpotifyThemeTrack { get; set; }

        [JsonProperty("common_connections")]
        public object[] CommonConnections { get; set; }

        [JsonProperty("is_travelling")]
        public bool IsTravelling { get; set; }

        [JsonProperty("teasers")]
        public Teaser[] Teasers { get; set; }

        [JsonProperty("hide_age")]
        public bool HideAge { get; set; }

        [JsonProperty("hide_distance")]
        public bool HideDistance { get; set; }

        [JsonProperty("user_interests")]
        public UserInterests UserInterests { get; set; }

        [JsonProperty("common_like_count")]
        public long CommonLikeCount { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("common_interests")]
        public object[] CommonInterests { get; set; }

        [JsonProperty("matched_preferences")]
        public MatchedPreferences MatchedPreferences { get; set; }

        [JsonProperty("is_tinder_u")]
        public bool IsTinderU { get; set; }

        //[JsonProperty("common_connections")]
        //public IList<CommonConnection> CommonConnections { get; set; }

        [JsonProperty("connection_count")] public int ConnectionCount { get; set; }

        [JsonProperty("common_likes")] public IList<object> CommonLikes { get; set; }

        //[JsonProperty("common_interests")]
        //public IList<CommonInterest> CommonInterests { get; set; }

        [JsonProperty("online_now")] public bool IsOnline { get; set; }

        [JsonProperty("common_friends")] public IList<object> CommonFriends { get; set; }

        [JsonProperty("relationship_intent")] public RelationshipIntent? RelationshipIntent { get; set; }

        [JsonProperty("content_hash")] public string ContentHash { get; set; }

        [JsonProperty("_id")] public string Id { get; set; }

        [JsonProperty("badges")] public IList<TinderBadge> Badges { get; set; }

        [JsonProperty("bio")] public string Bio { get; set; }

        [JsonProperty("birth_date")] public DateTime BirthDate { get; set; }

        [JsonProperty("gender")] public int Gender { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("ping_time")] public DateTime PingTime { get; set; }

        [JsonProperty("photos")] public IList<RecommendationPhoto> Photos { get; set; }

        [JsonProperty("jobs")] public IList<Job>? Jobs { get; set; }

        [JsonProperty("schools")] public IList<School> Schools { get; set; }

        [JsonProperty("birth_date_info")] public string BirthDateInfo { get; set; }

        [JsonProperty("is_traveling")] public bool? IsTraveling { get; set; }

        //[JsonProperty("instagram")]
        //public Instagram Instagram { get; set; }

        [JsonProperty("uncommon_interests")] public IList<object> UncommonInterests { get; set; }
    }
}