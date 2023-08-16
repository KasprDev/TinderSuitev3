namespace TinderSuitev3.Objects
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ViewProfileDto
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("results")]
        public TinderUser Results { get; set; }
    }

    public partial class City
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class MatchedPreferences
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("names")]
        public string[] Names { get; set; }

        [JsonProperty("has_bio")]
        public bool HasBio { get; set; }
    }

    public partial class Asset
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("asset_type")]
        public string AssetType { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }

    public partial class CropInfo
    {
        [JsonProperty("faces")]
        public Face[] Faces { get; set; }
    }

    public partial class Face
    {
        [JsonProperty("algo")]
        public Algo Algo { get; set; }

        [JsonProperty("bounding_box_percentage")]
        public double BoundingBoxPercentage { get; set; }
    }

    public partial class User
    {
        [JsonProperty("width_pct")]
        public long WidthPct { get; set; }

        [JsonProperty("x_offset_pct")]
        public long XOffsetPct { get; set; }

        [JsonProperty("height_pct")]
        public double HeightPct { get; set; }

        [JsonProperty("y_offset_pct")]
        public double YOffsetPct { get; set; }
    }

    public partial class HiddenIntent
    {
        [JsonProperty("image_url")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("title_text")]
        public string TitleText { get; set; }

        [JsonProperty("body_text")]
        public string BodyText { get; set; }
    }

    public partial class TappedAction
    {
        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("query_params")]
        public QueryParams QueryParams { get; set; }
    }

    public partial class QueryParams
    {
        [JsonProperty("component_id")]
        public string ComponentId { get; set; }
    }

    public partial class Artist
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class IconUrl
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("quality")]
        public string Quality { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }

    public partial class MeasurableSelection
    {
        [JsonProperty("min")]
        public long Min { get; set; }

        [JsonProperty("max")]
        public long Max { get; set; }
    }

    public partial class SpotifyThemeTrack
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("album")]
        public Album Album { get; set; }

        [JsonProperty("artists")]
        public Artist[] Artists { get; set; }

        [JsonProperty("preview_url")]
        public Uri PreviewUrl { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public partial class Album
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("images")]
        public Image[] Images { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class Teaser
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("string")]
        public string String { get; set; }
    }
}
